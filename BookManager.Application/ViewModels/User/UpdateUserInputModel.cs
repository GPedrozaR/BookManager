﻿namespace BookManager.Application.ViewModels.User
{
    public class UpdateUserInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}