using Microsoft.AspNetCore.Authentication.Cookies;
using MEPlatform.Web.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorPages();

// Configure Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("SuperAdministrator", policy => policy.RequireRole("SuperAdministrator"));
    options.AddPolicy("Supervisor", policy => policy.RequireRole("SuperAdministrator", "Supervisor"));
    options.AddPolicy("ProgramManager", policy => policy.RequireRole("SuperAdministrator", "Supervisor", "ProgramManager"));
    options.AddPolicy("Viewer", policy => policy.RequireRole("SuperAdministrator", "Supervisor", "ProgramManager", "Viewer"));
});

// Add HttpContext accessor
builder.Services.AddHttpContextAccessor();

// Add HTTP clients
builder.Services.AddHttpClient<AuthService>();
builder.Services.AddHttpClient<FrameworkApiService>();
builder.Services.AddHttpClient<ProgramApiService>();
builder.Services.AddHttpClient<MonitoringApiService>();

// Add application services
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<FrameworkApiService>();
builder.Services.AddScoped<ProgramApiService>();
builder.Services.AddScoped<MonitoringApiService>();

// Add AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
