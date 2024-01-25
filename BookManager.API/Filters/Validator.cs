using Microsoft.AspNetCore.Mvc.Filters;

namespace BookManager.API.Filters
{
    public class Validator : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
