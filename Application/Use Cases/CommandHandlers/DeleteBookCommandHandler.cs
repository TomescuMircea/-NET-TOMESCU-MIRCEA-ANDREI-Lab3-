﻿using Application.Use_Cases.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.CommandHandlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Guid>
    {
        private readonly IBookRepository repository;

        public DeleteBookCommandHandler(IBookRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Guid> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            return await repository.DeleteAsync(request.id);
        }
    }
}
