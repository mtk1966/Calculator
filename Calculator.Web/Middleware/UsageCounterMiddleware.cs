using Calculator.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator.Web.Middleware
{
    public class UsageCounterMiddleware
    {
        private readonly RequestDelegate _next;

        public UsageCounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, CalculatorDbContext dbContext)
        {
            if (context.Request.Method == "POST")
            {
                var usagePeriod = await dbContext.UsagePeriod.FirstOrDefaultAsync();
                if (usagePeriod == null)
                {
                    usagePeriod = new Common.Models.UsagePeriod();
                    dbContext.UsagePeriod.Add(usagePeriod);
                }

                usagePeriod.Usageperiod++;
                await dbContext.SaveChangesAsync();
            }

            await _next(context);
        }
    }
}
