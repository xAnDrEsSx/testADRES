using AutoMapper;
using TestADRES.Application.Features.Suppliers.Queries.GetAllSuppliers;
using TestADRES.Domain.Entities;

namespace TestADRES.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Supplier, SuppliersVm>();
        }
    }

}
