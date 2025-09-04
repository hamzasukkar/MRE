using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Services;

namespace MEPlatform.Web.Pages.Frameworks
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly FrameworkApiService _frameworkApiService;

        public DetailsModel(FrameworkApiService frameworkApiService)
        {
            _frameworkApiService = frameworkApiService;
        }

        public FrameworkDetails? Framework { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                // For now, we'll use mock data until the API DTOs are fully implemented
                Framework = CreateMockFrameworkDetails(id);
                
                if (Framework == null)
                {
                    return NotFound();
                }
                
                return Page();
            }
            catch (Exception)
            {
                // If API call fails, use mock data as fallback
                Framework = CreateMockFrameworkDetails(id);
                return Framework != null ? Page() : NotFound();
            }
        }

        private FrameworkDetails? CreateMockFrameworkDetails(int id)
        {
            return id switch
            {
                1 => new FrameworkDetails
                {
                    Id = 1,
                    Name = "SNDV Framework",
                    Description = "Syria National Development Vision 2030 - comprehensive framework for national reconstruction and development priorities focusing on economic recovery, social development, governance, infrastructure, and peace building.",
                    Type = "SNDV",
                    IsActive = true,
                    ElementsCount = 24,
                    IndicatorsCount = 156,
                    ProjectsCount = 18,
                    MeasurementsCount = 487,
                    OverallProgress = 78.5m,
                    CreatedAt = new DateTime(2024, 1, 15),
                    Elements = new List<FrameworkElementSummary>
                    {
                        new FrameworkElementSummary
                        {
                            Id = 1,
                            Name = "Economic Recovery and Development",
                            Description = "Rebuilding economic foundations and promoting sustainable growth",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 45
                        },
                        new FrameworkElementSummary
                        {
                            Id = 2,
                            Name = "Social Development and Human Capital",
                            Description = "Strengthening social services and human development",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 38
                        },
                        new FrameworkElementSummary
                        {
                            Id = 3,
                            Name = "Governance and Institution Building",
                            Description = "Establishing effective governance and institutional frameworks",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 28
                        },
                        new FrameworkElementSummary
                        {
                            Id = 4,
                            Name = "Infrastructure and Environment",
                            Description = "Rebuilding critical infrastructure and environmental sustainability",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 32
                        },
                        new FrameworkElementSummary
                        {
                            Id = 5,
                            Name = "Peace and Security",
                            Description = "Promoting peace, stability and community security",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 13
                        },
                        // Sub-elements for Economic Recovery
                        new FrameworkElementSummary
                        {
                            Id = 6,
                            Name = "Private Sector Development",
                            Description = "Supporting business growth and entrepreneurship",
                            Level = 2,
                            ParentId = 1,
                            IndicatorCount = 15
                        },
                        new FrameworkElementSummary
                        {
                            Id = 7,
                            Name = "Employment and Livelihoods",
                            Description = "Creating job opportunities and sustainable livelihoods",
                            Level = 2,
                            ParentId = 1,
                            IndicatorCount = 18
                        },
                        new FrameworkElementSummary
                        {
                            Id = 8,
                            Name = "Financial Services Access",
                            Description = "Improving access to banking and financial services",
                            Level = 2,
                            ParentId = 1,
                            IndicatorCount = 12
                        }
                    }
                },
                2 => new FrameworkDetails
                {
                    Id = 2,
                    Name = "Programs Framework",
                    Description = "Comprehensive program management and coordination framework for multi-sectoral development initiatives across Syria.",
                    Type = "Programs",
                    IsActive = true,
                    ElementsCount = 18,
                    IndicatorsCount = 89,
                    ProjectsCount = 21,
                    MeasurementsCount = 324,
                    OverallProgress = 65.3m,
                    CreatedAt = new DateTime(2024, 2, 1),
                    Elements = new List<FrameworkElementSummary>
                    {
                        new FrameworkElementSummary
                        {
                            Id = 9,
                            Name = "Program Planning and Design",
                            Description = "Strategic planning and program design methodologies",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 22
                        },
                        new FrameworkElementSummary
                        {
                            Id = 10,
                            Name = "Implementation Management",
                            Description = "Program implementation oversight and management",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 25
                        },
                        new FrameworkElementSummary
                        {
                            Id = 11,
                            Name = "Monitoring and Evaluation",
                            Description = "Comprehensive M&E systems and processes",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 19
                        },
                        new FrameworkElementSummary
                        {
                            Id = 12,
                            Name = "Resource Management",
                            Description = "Financial and human resource management",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 15
                        },
                        new FrameworkElementSummary
                        {
                            Id = 13,
                            Name = "Stakeholder Coordination",
                            Description = "Multi-stakeholder engagement and coordination",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 8
                        }
                    }
                },
                3 => new FrameworkDetails
                {
                    Id = 3,
                    Name = "SDG Framework",
                    Description = "Sustainable Development Goals alignment and monitoring framework adapted for Syria's context and development priorities.",
                    Type = "SDG",
                    IsActive = true,
                    ElementsCount = 17,
                    IndicatorsCount = 231,
                    ProjectsCount = 8,
                    MeasurementsCount = 156,
                    OverallProgress = 82.1m,
                    CreatedAt = new DateTime(2024, 1, 30),
                    Elements = new List<FrameworkElementSummary>
                    {
                        new FrameworkElementSummary
                        {
                            Id = 14,
                            Name = "No Poverty (SDG 1)",
                            Description = "End poverty in all its forms everywhere",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 15
                        },
                        new FrameworkElementSummary
                        {
                            Id = 15,
                            Name = "Zero Hunger (SDG 2)",
                            Description = "End hunger, achieve food security and improved nutrition",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 18
                        },
                        new FrameworkElementSummary
                        {
                            Id = 16,
                            Name = "Good Health and Well-being (SDG 3)",
                            Description = "Ensure healthy lives and promote well-being for all",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 24
                        },
                        new FrameworkElementSummary
                        {
                            Id = 17,
                            Name = "Quality Education (SDG 4)",
                            Description = "Ensure inclusive and equitable quality education",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 19
                        },
                        new FrameworkElementSummary
                        {
                            Id = 18,
                            Name = "Gender Equality (SDG 5)",
                            Description = "Achieve gender equality and empower all women and girls",
                            Level = 1,
                            ParentId = null,
                            IndicatorCount = 16
                        }
                    }
                },
                _ => null
            };
        }
    }

    public class FrameworkDetails
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int ElementsCount { get; set; }
        public int IndicatorsCount { get; set; }
        public int ProjectsCount { get; set; }
        public int MeasurementsCount { get; set; }
        public decimal? OverallProgress { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<FrameworkElementSummary> Elements { get; set; } = new();
    }

    public class FrameworkElementSummary
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Level { get; set; }
        public int? ParentId { get; set; }
        public int IndicatorCount { get; set; }
    }
}