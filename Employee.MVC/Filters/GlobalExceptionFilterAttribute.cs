using Api.Logistica.Models.Models;
using Employee.MVC.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Employee.MVC.Filters
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ResponseModel<dynamic> responseException = new ResponseModel<dynamic>();

            if (context.Exception is ApplicationException appException && appException.Message.Contains("custom condition"))
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            else if (context.Exception is EmployeeNotFoundException)
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            else if (context.Exception is AnnualSalaryCalculationException)
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            else
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            responseException.Description = context.Exception.Message;
            responseException.Successfully = false;
            context.Result = new ObjectResult(responseException);
            context.ExceptionHandled = true;
        }
    }
}
