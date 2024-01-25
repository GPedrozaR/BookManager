using BookManager.Application.Commands.Loan.CreateLoan;
using BookManager.Application.Queries.Loan.GetLoanById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetLoanById(int id)
        {
            var command = new GetLoanByIdQuery(id);
            
            var loan = await _mediator.Send(command);
            return loan is null
                ? NotFound()
                : Ok(loan);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewLoan([FromBody] CreateLoanCommand command)
        {
            var id = await _mediator.Send(command);

            return Created("Loan Created With Success", id);
        }
    }
}
