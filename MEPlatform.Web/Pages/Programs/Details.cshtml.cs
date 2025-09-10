using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Programs
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        public ProgramDetail Program { get; set; } = new();
        public List<ProjectSummary> Projects { get; set; } = new();
        public List<IndicatorSummary> KeyIndicators { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Program = GetMockProgramDetails(id);
                if (Program == null)
                {
                    return NotFound();
                }

                Projects = GetMockProjectsForProgram(id);
                KeyIndicators = GetMockKeyIndicators(id);
                
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("./Index");
            }
        }

        private ProgramDetail? GetMockProgramDetails(int id)
        {
            var programs = new List<ProgramDetail>
            {
                new()
                {
                    Id = 1,
                    Name = "Syrian Healthcare Infrastructure Recovery",
                    Description = "Comprehensive program to rebuild and modernize healthcare infrastructure across Syria, focusing on primary healthcare centers and specialized medical facilities.",
                    Status = "Active",
                    Budget = 15000000,
                    StartDate = new DateTime(2024, 1, 15),
                    EndDate = new DateTime(2025, 12, 31),
                    CreatedAt = new DateTime(2023, 11, 1),
                    UpdatedAt = DateTime.Now,
                    OverallProgress = 68.4m,
                    ProjectsCount = 12,
                    CompletedProjects = 3,
                    ActiveProjects = 8,
                    OnHoldProjects = 1,
                    Trend = 2.3m,
                    Performance = 78.5m,
                    FinancialPerformance = 82.1m,
                    PhysicalPerformance = 75.8m,
                    OtherPerformance = 77.2m,
                    Sectors = new List<string> { "Health", "Infrastructure", "Emergency Response" },
                    Regions = new List<string> { "Damascus", "Aleppo", "Homs", "Latakia" },
                    Framework = "SNDV Framework",
                    ResponsibleOrganization = "Ministry of Health",
                    TotalBeneficiaries = 2500000,
                    DirectBeneficiaries = 850000,
                    IndirectBeneficiaries = 1650000
                },
                new()
                {
                    Id = 2,
                    Name = "Education System Restoration Program",
                    Description = "Multi-year program to restore educational infrastructure, train teachers, and provide educational materials to ensure quality education access for all Syrian children.",
                    Status = "Active",
                    Budget = 25000000,
                    StartDate = new DateTime(2024, 2, 1),
                    EndDate = new DateTime(2026, 8, 31),
                    CreatedAt = new DateTime(2023, 12, 15),
                    UpdatedAt = DateTime.Now,
                    OverallProgress = 45.2m,
                    ProjectsCount = 18,
                    CompletedProjects = 2,
                    ActiveProjects = 14,
                    OnHoldProjects = 2,
                    Trend = 1.8m,
                    Performance = 72.3m,
                    FinancialPerformance = 74.5m,
                    PhysicalPerformance = 70.1m,
                    OtherPerformance = 73.2m,
                    Sectors = new List<string> { "Education", "Infrastructure", "Capacity Building" },
                    Regions = new List<string> { "Damascus", "Aleppo", "Daraa", "Homs", "Tartous" },
                    Framework = "SDG Framework",
                    ResponsibleOrganization = "Ministry of Education",
                    TotalBeneficiaries = 1800000,
                    DirectBeneficiaries = 650000,
                    IndirectBeneficiaries = 1150000
                }
            };

            return programs.FirstOrDefault(p => p.Id == id);
        }

        private List<ProjectSummary> GetMockProjectsForProgram(int programId)
        {
            if (programId == 1) // Healthcare program
            {
                return new List<ProjectSummary>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Primary Healthcare Centers Rehabilitation",
                        Description = "Renovation of 25 primary healthcare centers",
                        Status = "Active",
                        Progress = 75.2m,
                        Region = "Damascus",
                        Sector = "Health",
                        StartDate = new DateTime(2024, 1, 15),
                        EndDate = new DateTime(2024, 12, 31),
                        Budget = 2500000,
                        FinancialPerformance = 78.1m,
                        PhysicalPerformance = 72.3m,
                        Trend = 2.8m
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Medical Equipment Procurement",
                        Description = "Purchase and installation of essential medical equipment",
                        Status = "Active",
                        Progress = 62.8m,
                        Region = "Aleppo",
                        Sector = "Health",
                        StartDate = new DateTime(2024, 3, 1),
                        EndDate = new DateTime(2025, 2, 28),
                        Budget = 3500000,
                        FinancialPerformance = 65.4m,
                        PhysicalPerformance = 60.2m,
                        Trend = 1.5m
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Healthcare Staff Training Program",
                        Description = "Comprehensive training for healthcare professionals",
                        Status = "Completed",
                        Progress = 100.0m,
                        Region = "Homs",
                        Sector = "Health",
                        StartDate = new DateTime(2024, 1, 1),
                        EndDate = new DateTime(2024, 6, 30),
                        Budget = 800000,
                        FinancialPerformance = 98.7m,
                        PhysicalPerformance = 100.0m,
                        Trend = 0.0m
                    }
                };
            }
            else if (programId == 2) // Education program
            {
                return new List<ProjectSummary>
                {
                    new()
                    {
                        Id = 4,
                        Name = "School Infrastructure Rebuilding",
                        Description = "Reconstruction of damaged school buildings",
                        Status = "Active",
                        Progress = 48.5m,
                        Region = "Damascus",
                        Sector = "Education",
                        StartDate = new DateTime(2024, 2, 1),
                        EndDate = new DateTime(2025, 8, 31),
                        Budget = 8500000,
                        FinancialPerformance = 52.1m,
                        PhysicalPerformance = 44.9m,
                        Trend = 2.3m
                    },
                    new()
                    {
                        Id = 5,
                        Name = "Teacher Training Initiative",
                        Description = "Professional development for educators",
                        Status = "Active",
                        Progress = 67.2m,
                        Region = "Aleppo",
                        Sector = "Education",
                        StartDate = new DateTime(2024, 3, 15),
                        EndDate = new DateTime(2025, 3, 14),
                        Budget = 1200000,
                        FinancialPerformance = 69.8m,
                        PhysicalPerformance = 64.6m,
                        Trend = 1.9m
                    }
                };
            }

            return new List<ProjectSummary>();
        }

        private List<IndicatorSummary> GetMockKeyIndicators(int programId)
        {
            if (programId == 1) // Healthcare program
            {
                return new List<IndicatorSummary>
                {
                    new()
                    {
                        Id = 12,
                        Name = "Healthcare facilities restored",
                        ElementId = 2,
                        Unit = "facilities",
                        Target = 25,
                        CurrentValue = 19,
                        Description = "Number of healthcare facilities fully operational",
                        Performance = 76.0m,
                        FinancialPerformance = 78.2m,
                        PhysicalPerformance = 73.8m,
                        Trend = 3.1m
                    },
                    new()
                    {
                        Id = 13,
                        Name = "Healthcare staff trained",
                        ElementId = 2,
                        Unit = "staff",
                        Target = 500,
                        CurrentValue = 412,
                        Description = "Number of healthcare professionals trained",
                        Performance = 82.4m,
                        FinancialPerformance = 85.1m,
                        PhysicalPerformance = 79.7m,
                        Trend = 4.2m
                    }
                };
            }
            else if (programId == 2) // Education program
            {
                return new List<IndicatorSummary>
                {
                    new()
                    {
                        Id = 14,
                        Name = "Schools rebuilt",
                        ElementId = 7,
                        Unit = "schools",
                        Target = 45,
                        CurrentValue = 22,
                        Description = "Number of schools fully reconstructed",
                        Performance = 48.9m,
                        FinancialPerformance = 52.3m,
                        PhysicalPerformance = 45.5m,
                        Trend = 2.1m
                    },
                    new()
                    {
                        Id = 15,
                        Name = "Students enrolled",
                        ElementId = 7,
                        Unit = "students",
                        Target = 25000,
                        CurrentValue = 18750,
                        Description = "Number of students enrolled in restored schools",
                        Performance = 75.0m,
                        FinancialPerformance = 77.8m,
                        PhysicalPerformance = 72.2m,
                        Trend = 3.5m
                    }
                };
            }

            return new List<IndicatorSummary>();
        }
    }
}