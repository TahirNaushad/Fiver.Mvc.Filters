using Fiver.Mvc.Filters.Models.Home;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fiver.Mvc.Filters.Filters
{
    public class GreetingServiceFilter : IActionFilter
    {
        private readonly IGreetingService greetingService;

        public GreetingServiceFilter(IGreetingService greetingService)
        {
            this.greetingService = greetingService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments["param"] = this.greetingService.Greet("James Bond");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
