using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MEPlatform.Web.Models;

namespace MEPlatform.Web.Pages.Measures
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        public MeasureDetail Measure { get; set; } = new();
        public List<MeasureDataPoint> HistoricalData { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                Measure = GetMockMeasureDetails(id);
                if (Measure == null)
                {
                    return NotFound();
                }

                HistoricalData = GetMockHistoricalData(id);
                
                return Page();
            }
            catch (Exception)
            {
                return RedirectToPage("./Index");
            }
        }

        private MeasureDetail? GetMockMeasureDetails(int id)
        {
            var measures = new List<MeasureDetail>
            {
                new()
                {
                    Id = 1,
                    Name = "Number of primary healthcare centers operational",
                    Description = "Tracks the count of fully operational primary healthcare centers serving communities. This includes centers that have completed infrastructure rehabilitation, are adequately staffed, have necessary medical equipment, and are providing essential healthcare services to the population.",
                    Unit = "facilities",
                    MeasureType = "Quantitative",
                    DataSource = "Ministry of Health Records and Field Verification Reports",
                    CollectionMethod = "Monthly field verification visits combined with administrative reporting from facility managers",
                    Frequency = "Monthly",
                    Target = 25,
                    CurrentValue = 19,
                    BaselineValue = 8,
                    LastUpdated = DateTime.Now.AddDays(-5),
                    CreatedAt = new DateTime(2024, 1, 15),
                    IndicatorId = 1,
                    IndicatorName = "Healthcare facilities restored",
                    ProjectId = 1,
                    ProjectName = "Syrian Healthcare Infrastructure Recovery",
                    Status = "Active",
                    FinancialPerformance = 78.2m,
                    PhysicalPerformance = 76.0m,
                    Trend = 3.1m,
                    Achievement = 76.0m,
                    DataQuality = "High",
                    IsVerified = true,
                    ResponsiblePerson = "Dr. Ahmad Hassan",
                    Framework = "SNDV Framework",
                    Region = "Damascus",
                    Sector = "Health"
                },
                new()
                {
                    Id = 2,
                    Name = "Healthcare professionals trained and certified",
                    Description = "Number of healthcare workers who completed comprehensive training programs and received official certification. Training includes clinical skills, patient care protocols, equipment operation, and emergency response procedures.",
                    Unit = "persons",
                    MeasureType = "Quantitative",
                    DataSource = "Training Department Records and Certification Database",
                    CollectionMethod = "Training completion certificates and skills assessment records",
                    Frequency = "Quarterly",
                    Target = 500,
                    CurrentValue = 412,
                    BaselineValue = 150,
                    LastUpdated = DateTime.Now.AddDays(-12),
                    CreatedAt = new DateTime(2024, 1, 20),
                    IndicatorId = 2,
                    IndicatorName = "Healthcare staff trained",
                    ProjectId = 1,
                    ProjectName = "Syrian Healthcare Infrastructure Recovery",
                    Status = "Active",
                    FinancialPerformance = 85.1m,
                    PhysicalPerformance = 82.4m,
                    Trend = 4.2m,
                    Achievement = 82.4m,
                    DataQuality = "High",
                    IsVerified = true,
                    ResponsiblePerson = "Dr. Fatima Al-Zahra",
                    Framework = "SNDV Framework",
                    Region = "Damascus",
                    Sector = "Health"
                },
                new()
                {
                    Id = 3,
                    Name = "Schools fully reconstructed and operational",
                    Description = "Number of school buildings that have been completely rebuilt from foundation to meet modern educational standards, equipped with necessary facilities, and are operational with enrolled students and active teaching staff.",
                    Unit = "schools",
                    MeasureType = "Quantitative",
                    DataSource = "Ministry of Education Infrastructure Department",
                    CollectionMethod = "Engineering assessments, enrollment verification, and educational activity reports",
                    Frequency = "Monthly",
                    Target = 45,
                    CurrentValue = 22,
                    BaselineValue = 5,
                    LastUpdated = DateTime.Now.AddDays(-8),
                    CreatedAt = new DateTime(2024, 2, 1),
                    IndicatorId = 3,
                    IndicatorName = "Schools rebuilt",
                    ProjectId = 2,
                    ProjectName = "Education System Restoration Program",
                    Status = "Active",
                    FinancialPerformance = 52.3m,
                    PhysicalPerformance = 48.9m,
                    Trend = 2.1m,
                    Achievement = 48.9m,
                    DataQuality = "Medium",
                    IsVerified = true,
                    ResponsiblePerson = "Eng. Omar Khalil",
                    Framework = "SDG Framework",
                    Region = "Aleppo",
                    Sector = "Education"
                }
            };

            return measures.FirstOrDefault(m => m.Id == id);
        }

        private List<MeasureDataPoint> GetMockHistoricalData(int measureId)
        {
            if (measureId == 1) // Healthcare centers
            {
                return new List<MeasureDataPoint>
                {
                    new()
                    {
                        Id = 1,
                        MeasureId = measureId,
                        Value = 8,
                        RecordedDate = new DateTime(2024, 1, 15),
                        Note = "Baseline measurement - initial operational centers",
                        RecordedBy = "Dr. Ahmad Hassan",
                        IsVerified = true,
                        VerificationSource = "Field verification team",
                        PerformanceScore = 32.0m
                    },
                    new()
                    {
                        Id = 2,
                        MeasureId = measureId,
                        Value = 11,
                        RecordedDate = new DateTime(2024, 2, 15),
                        Note = "3 additional centers completed rehabilitation",
                        RecordedBy = "Dr. Ahmad Hassan",
                        IsVerified = true,
                        VerificationSource = "Ministry inspection",
                        PerformanceScore = 44.0m
                    },
                    new()
                    {
                        Id = 3,
                        MeasureId = measureId,
                        Value = 14,
                        RecordedDate = new DateTime(2024, 3, 15),
                        Note = "Phase 2 completion - significant progress",
                        RecordedBy = "Dr. Ahmad Hassan",
                        IsVerified = true,
                        VerificationSource = "Independent assessment",
                        PerformanceScore = 56.0m
                    },
                    new()
                    {
                        Id = 4,
                        MeasureId = measureId,
                        Value = 16,
                        RecordedDate = new DateTime(2024, 4, 15),
                        Note = "2 centers operational after equipment installation",
                        RecordedBy = "Dr. Ahmad Hassan",
                        IsVerified = true,
                        VerificationSource = "Field verification team",
                        PerformanceScore = 64.0m
                    },
                    new()
                    {
                        Id = 5,
                        MeasureId = measureId,
                        Value = 19,
                        RecordedDate = DateTime.Now.AddDays(-5),
                        Note = "Latest update - 3 more centers fully operational",
                        RecordedBy = "Dr. Ahmad Hassan",
                        IsVerified = true,
                        VerificationSource = "Ministry verification",
                        PerformanceScore = 76.0m
                    }
                };
            }
            else if (measureId == 2) // Healthcare staff trained
            {
                return new List<MeasureDataPoint>
                {
                    new()
                    {
                        Id = 6,
                        MeasureId = measureId,
                        Value = 150,
                        RecordedDate = new DateTime(2024, 1, 20),
                        Note = "Baseline - existing trained staff",
                        RecordedBy = "Dr. Fatima Al-Zahra",
                        IsVerified = true,
                        VerificationSource = "HR records",
                        PerformanceScore = 30.0m
                    },
                    new()
                    {
                        Id = 7,
                        MeasureId = measureId,
                        Value = 245,
                        RecordedDate = new DateTime(2024, 4, 20),
                        Note = "Q1 training cohort completion",
                        RecordedBy = "Dr. Fatima Al-Zahra",
                        IsVerified = true,
                        VerificationSource = "Training certificates",
                        PerformanceScore = 49.0m
                    },
                    new()
                    {
                        Id = 8,
                        MeasureId = measureId,
                        Value = 356,
                        RecordedDate = new DateTime(2024, 7, 20),
                        Note = "Q2 training program results",
                        RecordedBy = "Dr. Fatima Al-Zahra",
                        IsVerified = true,
                        VerificationSource = "Assessment scores",
                        PerformanceScore = 71.2m
                    },
                    new()
                    {
                        Id = 9,
                        MeasureId = measureId,
                        Value = 412,
                        RecordedDate = DateTime.Now.AddDays(-12),
                        Note = "Q3 completion - exceeding expectations",
                        RecordedBy = "Dr. Fatima Al-Zahra",
                        IsVerified = true,
                        VerificationSource = "Final evaluations",
                        PerformanceScore = 82.4m
                    }
                };
            }
            else if (measureId == 3) // Schools rebuilt
            {
                return new List<MeasureDataPoint>
                {
                    new()
                    {
                        Id = 10,
                        MeasureId = measureId,
                        Value = 5,
                        RecordedDate = new DateTime(2024, 2, 1),
                        Note = "Initial operational schools baseline",
                        RecordedBy = "Eng. Omar Khalil",
                        IsVerified = true,
                        VerificationSource = "Engineering assessment",
                        PerformanceScore = 11.1m
                    },
                    new()
                    {
                        Id = 11,
                        MeasureId = measureId,
                        Value = 12,
                        RecordedDate = new DateTime(2024, 5, 1),
                        Note = "Phase 1 reconstruction completion",
                        RecordedBy = "Eng. Omar Khalil",
                        IsVerified = true,
                        VerificationSource = "Construction completion certificates",
                        PerformanceScore = 26.7m
                    },
                    new()
                    {
                        Id = 12,
                        MeasureId = measureId,
                        Value = 18,
                        RecordedDate = new DateTime(2024, 7, 1),
                        Note = "6 additional schools completed and operational",
                        RecordedBy = "Eng. Omar Khalil",
                        IsVerified = true,
                        VerificationSource = "Ministry final inspection",
                        PerformanceScore = 40.0m
                    },
                    new()
                    {
                        Id = 13,
                        MeasureId = measureId,
                        Value = 22,
                        RecordedDate = DateTime.Now.AddDays(-8),
                        Note = "Latest progress update",
                        RecordedBy = "Eng. Omar Khalil",
                        IsVerified = true,
                        VerificationSource = "Field verification",
                        PerformanceScore = 48.9m
                    }
                };
            }

            return new List<MeasureDataPoint>();
        }
    }
}