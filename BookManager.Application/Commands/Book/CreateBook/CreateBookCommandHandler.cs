﻿using BookManager.Core.Repositories;
using MediatR;

namespace BookManager.Application.Commands.Book.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Core.Entities.Book(request.Title, request.Author, request.Isbn, request.PublishedYear);

            await _bookRepository.AddBookAsync(book);

            return book.Id;
        }
    }
}
