using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ValidarModelComMinimalAPI.Dtos;
using ValidarModelComMinimalAPI.Filters;
using ValidarModelComMinimalAPI.Validators;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IValidator<SingerDTO>, SingerValidator>();

var app = builder.Build();

app.MapPost("/singers", (HttpContext context, SingerDTO dto) => {
    return Results.Ok(dto);
}).AddEndpointFilter<SingerFilter>();

app.Run();
