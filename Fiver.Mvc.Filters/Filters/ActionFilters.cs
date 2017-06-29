using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Fiver.Mvc.Filters.Filters
{
    public class HelloActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // runs before action method
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // runs after action method
        }
    }

    public class HelloAsyncActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            // runs before action method
            await next();
            // runs after action method
        }
    }

    public class SkipActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.Result = new ContentResult
            {
                Content = "I'll skip the action execution"
            };
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Will not reach here
        }
    }

    public class ParseParameterActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            object param;
            if (context.ActionArguments.TryGetValue("param", out param))
                context.ActionArguments["param"] = param.ToString().ToUpper();
            else
                context.ActionArguments.Add("param", "I come from action filter");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
