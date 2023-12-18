
using FluentValidation;
using ValidarModelComMinimalAPI.Dtos;

namespace ValidarModelComMinimalAPI.Filters;

public class SingerFilter : IEndpointFilter
{
    private readonly IValidator<SingerDTO> _validator;

    public SingerFilter(IValidator<SingerDTO> validator)
    {
        _validator = validator;
    }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        
        Console.WriteLine("AQUUI");

        var obj = context.Arguments.FirstOrDefault(a => a!.GetType() == typeof(SingerDTO)) as SingerDTO;

        var result = await _validator.ValidateAsync(obj!);

        if (!result.IsValid) return Results.Json(result.Errors, statusCode: 400);


        return await next(context);
    }
}