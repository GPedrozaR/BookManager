﻿using MediatR;

namespace BookManager.Application.Commands.Book.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime PublishedYear { get; set; }
    }
}
