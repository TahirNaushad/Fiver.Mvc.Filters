using Fiver.Mvc.Filters.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fiver.Mvc.Filters.Filters
{
    public class GreetingTypeFilter : IActionFilter
    {
        private readonly IGreetingService greetingService;

        public GreetingTypeFilter(IGreetingService greetingService)
        {
            this.greetingService = greetingService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            context.ActionArguments["param"] = this.greetingService.Greet("Dr. No");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }

    public class GreetingTypeFilterWrapper : TypeFilterAttribute
    {
        public GreetingTypeFilterWrapper() : base(typeof(GreetingTypeFilter))
        {
        }
    }
}
