using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API.ActionFilters;

public class ValidationFilter<T> : IActionFilter where T : class
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var validator = context.HttpContext.RequestServices.GetService<IValidator<T>>();

        if (validator != null && context.ActionArguments.Values.FirstOrDefault(arg => arg is T) is T argument)
        {
            var validationResult = validator.Validate(argument);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                // Log.Warning("Validation failed: {Errors}", string.Join(", ", errors));
                context.Result = new BadRequestObjectResult(new
                {
                    statusCode = 400,
                    Message = string.Join(",", errors),
                    Details = "Validasiya xətası"
                });
                //throw context.Result;
            }
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {

    }
}

