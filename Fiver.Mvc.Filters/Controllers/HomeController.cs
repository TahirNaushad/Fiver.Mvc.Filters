using Microsoft.AspNetCore.Mvc;
using Fiver.Mvc.Filters.Filters;

namespace Fiver.Mvc.Filters.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region " Action Filters "

        [SkipActionFilter]
        public IActionResult SkipAction()
        {
            return Content("Hello SkipAction");
        }

        [ParseParameterActionFilter]
        public IActionResult ParseParameter(string param)
        {
            return Content($"Hello ParseParameter. Parameter: {param}");
        }

        #endregion

        #region " Result Filters "

        [SkipResultFilter]
        public IActionResult SkipResult()
        {
            return Content("Hello SkipResult");
        }

        [AddVersionResultFilter("ASP.NET Core MVC 1.1")]
        public IActionResult AddVersion()
        {
            return Content("Hello AddVersion. Check Response Headers for 'MVC-Version'");
        }

        #endregion

        #region " Service Filters "

        [ServiceFilter(typeof(GreetingServiceFilter))]
        public IActionResult GreetService(string param)
        {
            return Content($"Hello GreetService. Parameter: {param}");
        }
        
        #endregion

        #region " Type Filters "

        [TypeFilter(typeof(GreetingTypeFilter))]
        public IActionResult GreetType1(string param)
        {
            return Content($"Hello GreetType1. Parameter: {param}");
        }

        [GreetingTypeFilterWrapper]
        public IActionResult GreetType2(string param)
        {
            return Content($"Hello GreetType2. Parameter: {param}");
        }

        #endregion
    }
}
