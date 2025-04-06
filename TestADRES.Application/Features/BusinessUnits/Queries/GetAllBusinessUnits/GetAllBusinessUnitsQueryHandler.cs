using AutoMapper;
using MediatR;
using TestADRES.Application.Common;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Application.Wrappers;

namespace TestADRES.Application.Features.BusinessUnits.Queries.GetAllBusinessUnits
{
    public class GetAllBusinessUnitsQueryHandler : IRequestHandler<GetAllBusinessUnitsQuery, Response<List<BusinessUnitsVm>>>
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllBusinessUnitsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<Response<List<BusinessUnitsVm>>> Handle(GetAllBusinessUnitsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var businessUnits = await unitOfWork.BusinessUnitRepository.GetAllAsync();

                if (businessUnits == null || !businessUnits.Any())
                {
                    return new Response<List<BusinessUnitsVm>>([], GlobalMessages.NoBusinessUnitsFound);
                }

                return new Response<List<BusinessUnitsVm>>(mapper.Map<List<BusinessUnitsVm>>(businessUnits), GlobalMessages.BusinessUnitsRetrievedSuccessfully);

            }
            catch (Exception ex)
            {
                return new Response<List<BusinessUnitsVm>>(GlobalMessages.ErrorRetrievingBusinessUnits(ex.Message));
            }
        }
    }
}
