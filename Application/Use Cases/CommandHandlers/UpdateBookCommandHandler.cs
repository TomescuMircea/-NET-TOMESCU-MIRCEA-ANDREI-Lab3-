using Application.Use_Cases.Commands;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers
{
    public class UpdateBookCommandHandler:IRequestHandler<UpdateBookCommand,Guid>
    {
        private readonly IBookRepository repository;

        public UpdateBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Guid> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = request.Id,
                Title = request.Title,
                Author = request.Author,
                ISBN = request.ISBN,
                PublicationDate = request.PublicationDate
            };

            return await repository.UpdateAsync(book);
        }
    }
}
