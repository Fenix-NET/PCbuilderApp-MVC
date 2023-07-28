using Microsoft.AspNetCore.Builder;

namespace RestApi.Service2
{
    public static class OptionsVerbMiddlewareExtensions
    {
        public static IApplicationBuilder UseOptionsVerbHandler(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware.OptionsVerbMiddleware>();
        }
    }
}
