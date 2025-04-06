using AutoMapper;
using MediatR;
using TestADRES.Application.Contracts.Persistence;
using TestADRES.Application.Wrappers;
using System.Linq.Expressions;
using TestADRES.Application.Common;
using TestADRES.Domain.Entities;
using TestADRES.Application.Features.Requirements.Queries.GetAllRequirement;
using TestADRES.Application.Extensions;

namespace TestADRES.Application.Features.Requirements.Queries.GetFilteredRequirements
{
    public class GetFilteredRequirementsQueryHandler : IRequestHandler<GetFilteredRequirementsQuery, Response<List<GetAllRequirementVm>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetFilteredRequirementsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<Response<List<GetAllRequirementVm>>> Handle(GetFilteredRequirementsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Expression<Func<Requirement, bool>> predicate = r => true;

                if (request.SupplierId.HasValue)
                    predicate = predicate.AndAlso(r => r.SupplierId == request.SupplierId.Value);

                if (request.BusinessUnitId.HasValue && request.BusinessUnitId.Value > 0)
                    predicate = predicate.AndAlso(r => r.BusinessUnitId == request.BusinessUnitId.Value);

                if (request.RequirementStatusId.HasValue && request.RequirementStatusId.Value > 0)
                    predicate = predicate.AndAlso(r => r.RequirementStatusId == request.RequirementStatusId.Value);

                if (!string.IsNullOrEmpty(request.ItemType))
                    predicate = predicate.AndAlso(r => r.ItemType.Contains(request.ItemType));

                var requirements = await unitOfWork.RequirementRepository.GetAsync(predicate);

                if (requirements == null || !requirements.Any())
                {
                    return new Response<List<GetAllRequirementVm>>(GlobalMessages.NoRequirementFound);
                }

                var requirementsList = new List<GetAllRequirementVm>();

                foreach (var requirement in requirements.OrderByDescending(r => r.AcquisitionDate))
                {
                    var businessUnit = await unitOfWork.BusinessUnitRepository.GetByIdAsync(requirement.BusinessUnitId);

                    requirementsList.Add(new GetAllRequirementVm()
                    {
                        RequerimentId = requirement.Id,
                        AcquisitionDate = requirement.AcquisitionDate,
                        ItemtName = requirement.ItemType.Trim(),
                        TotalValue = requirement.UnitValue * requirement.Quantity,
                        UnitName = businessUnit.Name.Trim()
                    });
                }

                return new Response<List<GetAllRequirementVm>>(requirementsList, "Requirements retrieved successfully.");
            }
            catch (Exception ex)
            {
                return new Response<List<GetAllRequirementVm>>(GlobalMessages.ErrorRetrievingRequirementStatuses(ex.Message));
            }
        }
    }
}
