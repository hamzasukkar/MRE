using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Measures
{
    [Authorize(Roles = "SuperAdministrator,Supervisor,ProgramManager")]
    public class EditModel : PageModel
    {
        [BindProperty]
        public EditMeasureViewModel? Measure { get; set; }

        public List<ProjectSummary> Projects { get; set; } = new();
        public List<IndicatorSummary> Indicators { get; set; } = new();
        public List<string> MeasureTypes { get; set; } = new();
        public List<string> Frequencies { get; set; } = new();
        public List<string> Statuses { get; set; } = new();
        public List<string> DataQualityLevels { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Measure = GetMockMeasure(id);
            if (Measure == null)
            {
                return NotFound();
            }

            LoadFormData();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LoadFormData();
                return Page();
            }

            try
            {
                TempData["SuccessMessage"] = $"Measure '{Measure!.Name}' updated successfully.";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the measure.");
                LoadFormData();
                return Page();
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync()
        {
            try
            {
                TempData["SuccessMessage"] = "Measure deleted successfully.";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Failed to delete measure.";
                return RedirectToPage("./Index");
            }
        }

        private void LoadFormData()
        {
            Projects = GetMockProjects();
            Indicators = GetMockIndicators();
            
            MeasureTypes = new List<string>
            {
                "Quantitative",
                "Qualitative", 
                "Binary"
            };

            Frequencies = new List<string>
            {
                "Weekly",
                "Monthly",
                "Quarterly", 
                "Semi-annually",
                "Annually"
            };

            Statuses = new List<string>
            {
                "Active",
                "Planning",
                "On Hold",
                "Completed",
                "Cancelled"
            };

            DataQualityLevels = new List<string>
            {
                "High",
                "Medium",
                "Low"
            };
        }

        private EditMeasureViewModel? GetMockMeasure(int id)
        {
            var measures = new List<EditMeasureViewModel>
            {
                new()
                {
                    Id = 1,
                    Name = "Number of primary healthcare centers operational",
                    Description = "Tracks the count of fully operational primary healthcare centers serving communities",
                    Unit = "facilities",
                    MeasureType = "Quantitative",
                    DataSource = "Ministry of Health Records",
                    CollectionMethod = "Field verification and reporting",
                    Frequency = "Monthly",
                    Target = 25,
                    CurrentValue = 19,
                    BaselineValue = 8,
                    IndicatorId = 1,
                    ProjectId = 1,
                    Status = "Active",
                    FinancialPerformance = 78.2m,
                    PhysicalPerformance = 76.0m,
                    Trend = 3.1m,
                    Achievement = 76.0m,
                    CreatedAt = new DateTime(2024, 1, 15),
                    LastUpdated = DateTime.Now.AddDays(-5),
                    DataQuality = "High",
                    IsVerified = true,
                    ResponsiblePerson = "Dr. Ahmad Hassan"
                },
                new()
                {
                    Id = 2,
                    Name = "Healthcare professionals trained and certified",
                    Description = "Number of healthcare workers who completed training programs and received certification",
                    Unit = "persons",
                    MeasureType = "Quantitative",
                    DataSource = "Training Department Records",
                    CollectionMethod = "Training completion certificates",
                    Frequency = "Quarterly",
                    Target = 500,
                    CurrentValue = 412,
                    BaselineValue = 150,
                    IndicatorId = 2,
                    ProjectId = 1,
                    Status = "Active",
                    FinancialPerformance = 85.1m,
                    PhysicalPerformance = 82.4m,
                    Trend = 4.2m,
                    Achievement = 82.4m,
                    CreatedAt = new DateTime(2024, 1, 20),
                    LastUpdated = DateTime.Now.AddDays(-12),
                    DataQuality = "High",
                    IsVerified = true,
                    ResponsiblePerson = "Dr. Fatima Al-Zahra"
                },
                new()
                {
                    Id = 3,
                    Name = "Schools fully reconstructed and operational",
                    Description = "Number of school buildings that have been completely rebuilt and are operational",
                    Unit = "schools",
                    MeasureType = "Quantitative",
                    DataSource = "Ministry of Education",
                    CollectionMethod = "Engineering assessments and enrollment data",
                    Frequency = "Monthly",
                    Target = 45,
                    CurrentValue = 22,
                    BaselineValue = 5,
                    IndicatorId = 3,
                    ProjectId = 2,
                    Status = "Active",
                    FinancialPerformance = 52.3m,
                    PhysicalPerformance = 48.9m,
                    Trend = 2.1m,
                    Achievement = 48.9m,
                    CreatedAt = new DateTime(2024, 2, 1),
                    LastUpdated = DateTime.Now.AddDays(-8),
                    DataQuality = "Medium",
                    IsVerified = true,
                    ResponsiblePerson = "Eng. Omar Khalil"
                }
            };

            return measures.FirstOrDefault(m => m.Id == id);
        }

        private List<ProjectSummary> GetMockProjects()
        {
            return new List<ProjectSummary>
            {
                new()
                {
                    Id = 1,
                    Name = "Syrian Healthcare Infrastructure Recovery",
                    Description = "Comprehensive healthcare system restoration",
                    Status = "Active",
                    Region = "Damascus",
                    Sector = "Health"
                },
                new()
                {
                    Id = 2,
                    Name = "Education System Restoration Program", 
                    Description = "Multi-year education infrastructure program",
                    Status = "Active",
                    Region = "Aleppo",
                    Sector = "Education"
                },
                new()
                {
                    Id = 3,
                    Name = "Emergency Water Supply Project",
                    Description = "Critical water infrastructure rehabilitation",
                    Status = "Active",
                    Region = "Homs",
                    Sector = "Water & Sanitation"
                },
                new()
                {
                    Id = 4,
                    Name = "Community Health Centers Rehabilitation",
                    Description = "Primary healthcare centers restoration",
                    Status = "Active",
                    Region = "Daraa",
                    Sector = "Health"
                }
            };
        }

        private List<IndicatorSummary> GetMockIndicators()
        {
            return new List<IndicatorSummary>
            {
                new()
                {
                    Id = 1,
                    Name = "Healthcare facilities restored",
                    ElementId = 2,
                    Unit = "facilities",
                    Target = 25,
                    CurrentValue = 19,
                    Description = "Number of healthcare facilities fully operational"
                },
                new()
                {
                    Id = 2,
                    Name = "Healthcare staff trained",
                    ElementId = 2,
                    Unit = "staff",
                    Target = 500,
                    CurrentValue = 412,
                    Description = "Number of healthcare professionals trained"
                },
                new()
                {
                    Id = 3,
                    Name = "Schools rebuilt",
                    ElementId = 7,
                    Unit = "schools",
                    Target = 45,
                    CurrentValue = 22,
                    Description = "Number of schools fully reconstructed"
                },
                new()
                {
                    Id = 4,
                    Name = "Students enrolled",
                    ElementId = 7,
                    Unit = "students",
                    Target = 25000,
                    CurrentValue = 18750,
                    Description = "Number of students enrolled in restored schools"
                }
            };
        }
    }
}