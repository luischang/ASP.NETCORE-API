using M5_NETCORE.CORE.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;


namespace M5_NETCORE.INFRASTRUCTURE.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception.GetType()== typeof(GeneralException))
            {
                var exception = (GeneralException)filterContext.Exception;
                var validation = new
                {

                    Status = 400,
                    Title = "Bad Request API",
                    Detail = exception.Message
                };

                var json = new
                {
                    erros= new[] { validation}
                };

                filterContext.Result = new BadRequestObjectResult(json);
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                filterContext.ExceptionHandled = true;


            }
        }
    }
}
