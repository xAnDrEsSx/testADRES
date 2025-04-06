using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestADRES.Application.Features.RequirementStatuses.Queries.GetAllRequirementStatuses;
using TestADRES.Application.Wrappers;

namespace TestADRES.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequirementStatusController : ControllerBase
    {
        private readonly IMediator mediator;

        public RequirementStatusController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Name = "GetAllRequirementStatuses")]
        [ProducesResponseType(typeof(Response<List<RequirementStatusesVm>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response<List<RequirementStatusesVm>>>> GetAllRequirementStatuses()
        {
            return Ok(await mediator.Send(new GetAllRequirementStatusesQuery()));
        }
    }
}
