namespace NancyApplication.Config
{
    using System;
    using Nancy;
    using Nancy.Configuration;
    using Nancy.Conventions;

    public class NancyBootstrapper : DefaultNancyBootstrapper
    {
        public NancyBootstrapper()
        {
        }

        /* Unfortunately certain browsers and javascript frameworks do not 
        send valid accept headers, which could cause content negotiation to 
        return a non-deal content type. To work around this the negotiation pipeline 
        has a concept of “accept header coercion” that looks at the request and tweaks 
        the accept headers to try and smooth things out */
        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);

            this.Conventions.AcceptHeaderCoercionConventions.Add((acceptHeaders, ctx) =>
            {
                return new[] { Tuple.Create("application/json", 1M) };
            });
        }

        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(
                enabled: true,
                displayErrorTraces: true);
        }

        public NancyBootstrapper(AppConfiguration appConfig)
        {
            Console.WriteLine(appConfig.Smtp.Server);
            Console.WriteLine(appConfig.Smtp.User);
            Console.WriteLine(appConfig.Logging.IncludeScopes);
        }
    }
}