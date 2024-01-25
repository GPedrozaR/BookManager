using BookManager.Application.Commands.Book.CreateBook;
using BookManager.Application.Validators.User;
using BookManager.Core.Repositories;
using BookManager.Infrastructure.Persistence;
using BookManager.Infrastructure.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DbContext
var connectionString = builder.Configuration.GetConnectionString("BookManagerCs");
builder.Services.AddDbContext<BookManagerDbContext>(p => p.UseSqlServer(connectionString));

//Repository
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//FluentValidation
builder
    .Services
    .AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>()
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();

//CQRS - MediatR
builder.Services.AddMediatR(op => op.RegisterServicesFromAssemblyContaining(typeof(CreateBookCommand)));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
