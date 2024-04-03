using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PassIn.Communication.Responses;
using PassIn.Exceptions;
using System.Net;

namespace PassIn.Api.Filters;

public class ExeptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var result = context.Exception is PassInException;
        if (result)
        {
            HandleProjectExeption(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private void HandleProjectExeption(ExceptionContext context)
    {
        if (context.Exception is NotFoundException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound; //cast enum para int
            context.Result = new NotFoundObjectResult(context.Exception.Message);
        }
        else if (context.Exception is ErrorOnValidationException)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest; //cast enum para int
            context.Result = new BadRequestObjectResult(context.Exception.Message);
        }
        else if (context.Exception is ConflictExeption)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict; //cast enum para int
            context.Result = new ConflictObjectResult(context.Exception.Message);
        }
    }    

    private void ThrowUnknownError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest; //cast enum para int
        context.Result = new BadRequestObjectResult(context.Exception.Message);
    }
}
