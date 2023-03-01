using TEZAProject.Dal;

namespace TEZAProject.API.Infrastructure.Middlewares
{
     public class DbTransactionMiddleware
     {
          public class DbTransactionMiddleware
          {
               private readonly RequestDelegate _next;

               public DbTransactionMiddleware(RequestDelegate next)
               {
                    _next = next;
               }

               public async Task InvokeAsync(HttpContext httpContext, TEZAProjectDbContext dbContext)
               {
                    // For HTTP GET opening transaction is not required
                    if (httpContext.Request.Method.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
                    {
                         await _next(httpContext);
                         return;
                    }

                    using (var transaction = dbContext.Database.BeginTransaction());
                    { 
                         await _next(httpContext);
                         await dbContext.Database.CommitTransactionAsync();
                    }
               }


          }
     }
}
