using AutoMapper;
using MEPlatform.Application.DTOs.Frameworks;
using MEPlatform.Application.DTOs.Programs;
using MEPlatform.Core.Entities.Framework;
using MEPlatform.Core.Entities.Project;

namespace MEPlatform.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Framework mappings
        CreateMap<Framework, FrameworkDto>();
        CreateMap<Framework, FrameworkDetailsDto>();
        CreateMap<CreateFrameworkDto, Framework>();
        CreateMap<UpdateFrameworkDto, Framework>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // FrameworkElement mappings
        CreateMap<FrameworkElement, FrameworkElementDto>();
        CreateMap<CreateFrameworkElementDto, FrameworkElement>();
        CreateMap<UpdateFrameworkElementDto, FrameworkElement>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Indicator mappings
        CreateMap<Indicator, IndicatorDto>();
        CreateMap<CreateIndicatorDto, Indicator>();
        CreateMap<UpdateIndicatorDto, Indicator>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Measurement mappings
        CreateMap<Measurement, MeasurementDto>();
        CreateMap<CreateMeasurementDto, Measurement>();
        CreateMap<UpdateMeasurementDto, Measurement>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Program mappings
        CreateMap<Program, ProgramDto>();
        CreateMap<Program, ProgramDetailsDto>();
        CreateMap<CreateProgramDto, Program>();
        CreateMap<UpdateProgramDto, Program>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // ActionPlan mappings
        CreateMap<ActionPlan, ActionPlanDto>();
        CreateMap<CreateActionPlanDto, ActionPlan>();
        CreateMap<UpdateActionPlanDto, ActionPlan>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // Dimension mappings
        CreateMap<Dimension, DimensionDto>();
        CreateMap<CreateDimensionDto, Dimension>();
        CreateMap<UpdateDimensionDto, Dimension>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // LogicalFramework mappings
        CreateMap<LogicalFramework, LogicalFrameworkDto>();
        CreateMap<CreateLogicalFrameworkDto, LogicalFramework>();
        CreateMap<UpdateLogicalFrameworkDto, LogicalFramework>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // LogicalFrameworkIndicator mappings
        CreateMap<LogicalFrameworkIndicator, LogicalFrameworkIndicatorDto>();
        CreateMap<CreateLogicalFrameworkIndicatorDto, LogicalFrameworkIndicator>();
        CreateMap<UpdateLogicalFrameworkIndicatorDto, LogicalFrameworkIndicator>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // ProjectFile mappings
        CreateMap<ProjectFile, ProjectFileDto>();
    }
}