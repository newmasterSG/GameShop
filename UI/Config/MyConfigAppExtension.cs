namespace UI.ServiceProvider
{
    public static class MyConfigAppExtension
    {
        public static void Configure(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseIdentityServer();
        }
    }
}
