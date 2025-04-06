using AutoMapper;
using TestADRES.Application.Features.BusinessUnits.Queries.GetAllBusinessUnits;
using TestADRES.Application.Features.Requirements.Commands.CreateRequirement;
using TestADRES.Application.Features.RequirementStatuses.Queries.GetAllRequirementStatuses;
using TestADRES.Application.Features.Suppliers.Queries.GetAllSuppliers;
using TestADRES.Domain.Entities;

namespace TestADRES.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Supplier, SuppliersVm>();
            CreateMap<BusinessUnit, BusinessUnitsVm>();
            CreateMap<RequirementStatus, RequirementStatusesVm>();
            CreateMap<CreateRequirementCommand, Requirement>();
        }
    }

}
