using Application.DTOs;
using Application.Use_Cases.Commands;
using Application.Use_Cases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BooksControllers : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksControllers(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook(CreateBookCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateBookById(UpdateBookCommand command)
        {
            return await mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<BookDto>> GetBookById([FromQuery] GetBookByIdQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpGet("books")]
        public async Task<ActionResult<List<BookDto>>> GetAllBooks([FromQuery] GetAllBooksQuery query)
        {
            return await mediator.Send(query);
        }

        [HttpDelete]
        public async Task<ActionResult<Guid>> DeleteBookById([FromQuery] DeleteBookCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
