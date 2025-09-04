using MEPlatform.Infrastructure.Data;
using MEPlatform.Application.Services;
using MEPlatform.Infrastructure.Identity;
using MEPlatform.Core.Entities.Identity;
using MEPlatform.API.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using MEPlatform.Core.Enums;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MEPlatformDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<MEPlatformDbContext>()
.AddDefaultTokenProviders();

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Secret"]!)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

// Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.SuperAdministrator, 
        policy => policy.Requirements.Add(new RoleRequirement(UserRole.SuperAdministrator)));
    
    options.AddPolicy(Policies.CanManageFrameworks,
        policy => policy.Requirements.Add(new RoleRequirement(UserRole.SuperAdministrator, UserRole.Supervisor)));
    
    options.AddPolicy(Policies.CanManageProjects,
        policy => policy.Requirements.Add(new RoleRequirement(UserRole.SuperAdministrator, UserRole.Supervisor, UserRole.ProgramManager)));
    
    options.AddPolicy(Policies.CanViewReports,
        policy => policy.Requirements.Add(new RoleRequirement(UserRole.SuperAdministrator, UserRole.Supervisor, UserRole.ProgramManager, UserRole.Viewer)));
});

builder.Services.AddScoped<IAuthorizationHandler, RoleRequirementHandler>();

// Application Services
builder.Services.AddScoped<IIdentityService, IdentityService>();

// AutoMapper
builder.Services.AddAutoMapper(typeof(MEPlatform.Application.Profiles.MappingProfile));

// MediatR
builder.Services.AddMediatR(typeof(MEPlatform.Application.Services.IFrameworkService).Assembly);

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MEPlatform API", Version = "v1" });
    
    // Add JWT authentication to Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Please enter JWT token",
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy
            .WithOrigins("http://localhost:3000", "https://localhost:3000") // React app URLs
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Database Migration and Seeding
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MEPlatformDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    
    await context.Database.EnsureCreatedAsync();
    await SeedInitialDataAsync(context, userManager);
}

app.Run();

static async Task SeedInitialDataAsync(MEPlatformDbContext context, UserManager<ApplicationUser> userManager)
{
    // Create default admin user
    if (!await userManager.Users.AnyAsync())
    {
        var adminUser = new ApplicationUser
        {
            UserName = "admin@meplatform.com",
            Email = "admin@meplatform.com",
            FirstName = "System",
            LastName = "Administrator",
            Role = UserRole.SuperAdministrator,
            EmailConfirmed = true,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        await userManager.CreateAsync(adminUser, "Admin123!");
    }
}