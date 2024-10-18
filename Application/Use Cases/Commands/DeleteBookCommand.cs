using MediatR;

namespace Application.Use_Cases.Commands
{
    public class DeleteBookCommand : IRequest<Guid>
    {
        public Guid id { get; set; }

    }
}
