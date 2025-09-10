using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Measures
{
    [Authorize(Roles = "SuperAdministrator,Supervisor,ProgramManager")]
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateMeasureViewModel Measure { get; set; } = new();

        public List<ProjectSummary> Projects { get; set; } = new();
        public List<IndicatorSummary> Indicators { get; set; } = new();
        public List<string> MeasureTypes { get; set; } = new();
        public List<string> Frequencies { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
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
                TempData["SuccessMessage"] = $"Measure '{Measure.Name}' created successfully.";
                return RedirectToPage("./Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the measure.");
                LoadFormData();
                return Page();
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
                },
                new()
                {
                    Id = 5,
                    Name = "Teacher Training Initiative",
                    Description = "Professional development for educators",
                    Status = "Active",
                    Region = "Latakia",
                    Sector = "Education"
                },
                new()
                {
                    Id = 6,
                    Name = "Rural Healthcare Access Program",
                    Description = "Expanding healthcare to rural areas",
                    Status = "Planning",
                    Region = "Tartous",
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
                },
                new()
                {
                    Id = 5,
                    Name = "Water systems operational",
                    ElementId = 12,
                    Unit = "systems",
                    Target = 20,
                    CurrentValue = 14,
                    Description = "Number of water supply systems functioning"
                },
                new()
                {
                    Id = 6,
                    Name = "Communities served",
                    ElementId = 2,
                    Unit = "communities",
                    Target = 50,
                    CurrentValue = 38,
                    Description = "Number of communities receiving services"
                },
                new()
                {
                    Id = 7,
                    Name = "Medical equipment installed",
                    ElementId = 2,
                    Unit = "equipment units",
                    Target = 100,
                    CurrentValue = 78,
                    Description = "Medical equipment units installed and operational"
                },
                new()
                {
                    Id = 8,
                    Name = "Teacher certification rates",
                    ElementId = 7,
                    Unit = "percentage",
                    Target = 90,
                    CurrentValue = 73,
                    Description = "Percentage of teachers meeting certification requirements"
                }
            };
        }
    }
}