using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
