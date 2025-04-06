using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestADRES.Application.Features.Requirements.Commands.CreateRequirement;
using TestADRES.Application.Wrappers;

namespace TestADRES.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequirementController : ControllerBase
    {
        private readonly IMediator mediator;

        public RequirementController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost(Name = "“RequestRequeriment")]
        [ProducesResponseType(typeof(Response<Guid>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response<Guid>>> CreateRequeriment([FromBody] CreateRequirementCommand command)
        {
            return await mediator.Send(command);
        }

    }
}
