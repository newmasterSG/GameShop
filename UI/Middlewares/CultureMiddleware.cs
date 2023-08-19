namespace UI.Middlewares
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invole(HttpContext context)
        {
            var lang = context.Request.Query["lang"];
        }
    }
}
