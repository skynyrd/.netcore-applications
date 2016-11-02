using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Nancy.Owin;

namespace NancyApplication.Config
{
    public class Startup
    {
        public IConfiguration configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(env.ContentRootPath)
                .Build();
        }

        public void Configure(IApplicationBuilder app)
        {
            var appConfig = new AppConfiguration();

            ConfigurationBinder.Bind(this.configuration, appConfig);
            app.UseOwin(x => x.UseNancy(opt => opt.Bootstrapper = new NancyBootstrapper(appConfig)));
        }
    }
}