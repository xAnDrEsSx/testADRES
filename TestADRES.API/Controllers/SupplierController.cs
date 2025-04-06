using Azure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestADRES.Application.Features.Suppliers.Queries.GetAllSuppliers;

namespace TestADRES.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator mediator;

        public SupplierController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet(Name = "GetAllSuppliers")]
        [ProducesResponseType(typeof(Response<List<SuppliersVm>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Response<List<SuppliersVm>>>> GetAllSuppliers()
        {
            return Ok(await mediator.Send(new GetAllSuppliersQuery()));
        }

    }
}
