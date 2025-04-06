using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestADRES.Application.Features.Requirements.Commands.CreateRequirement;
using TestADRES.Application.Features.Requirements.Commands.UpdateRequirement;
using TestADRES.Application.Features.Requirements.Queries.GetAllRequirement;
using TestADRES.Application.Features.Requirements.Queries.GetRequirementById;
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

        [HttpGet(Name = "GetAllRequirements")]
        [ProducesResponseType(typeof(Response<List<GetAllRequirementVm>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response<List<GetAllRequirementVm>>>> GetAllRequirements()
        {
            return Ok(await mediator.Send(new GetAllRequirementQuery()));
        }


        [HttpGet("{Id}" , Name = "GetRequirementById")]
        [ProducesResponseType(typeof(Response<GetRequirementByIdVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response<GetRequirementByIdVm>>> GetRequirementById(string Id)
        {
            return Ok(await mediator.Send(new GetRequirementByIdQuery(Id)));
        }

        [HttpPatch(Name = "UpdateRequirement")]
        [ProducesResponseType(typeof(Response<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response<bool>>> UpdateRequirement([FromBody] UpdateRequirementCommand command)
        {
            if (!Guid.TryParse(command.RequirementId.ToString(), out var requirementId))
            {
                return BadRequest(new Response<bool>("Invalid GUID for requirement id."));
            }
            var result = await mediator.Send(command);
            return Ok(result);
        }



    }
}
