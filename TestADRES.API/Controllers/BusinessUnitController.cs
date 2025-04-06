using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestADRES.Application.Features.BusinessUnits.Queries.GetAllBusinessUnits;
using TestADRES.Application.Wrappers;

namespace TestADRES.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessUnitController : ControllerBase
    {
        private readonly IMediator mediator;

        public BusinessUnitController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Name = "GetAllBusinessUnits")]
        [ProducesResponseType(typeof(Response<List<BusinessUnitsVm>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response<List<BusinessUnitsVm>>>> GetAllBusinessUnits()
        {
            return Ok(await mediator.Send(new GetAllBusinessUnitsQuery()));
        }

    }
}
