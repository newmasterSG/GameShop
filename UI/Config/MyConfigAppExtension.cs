using Microsoft.AspNetCore.Localization;
using System.Globalization;
using UI.Hubs;

namespace UI.ServiceProvider
{
    public static class MyConfigAppExtension
    {
        public static void Configure(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("uk"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
            });
        }
    }
}
