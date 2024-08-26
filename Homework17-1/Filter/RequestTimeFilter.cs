using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Homework17_1.Filter
{
    public class RequestTimeFilter : IActionFilter
    {
        private Stopwatch _stopwatch;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            context.HttpContext.Response.Headers.Add(
                "X-Request-Time-Elapsed",
                _stopwatch.ElapsedMilliseconds.ToString()
            );
        }
    }
}
