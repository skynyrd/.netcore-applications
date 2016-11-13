using System;
using Nancy;
using Nancy.ModelBinding;
using NancyApplication.Domain;

namespace NancyApplication.Module
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args =>
            {
                return "Hello from Nancy!";
            });

            Get("test/{name}", args =>
            {
                return new Person() { Name = args.name };
            });

            Post("/", args =>
            {
                var person = this.BindAndValidate<Person>();

                if (!this.ModelValidationResult.IsValid)
                {
                    return Negotiate
                        .WithModel(this.ModelValidationResult.FormattedErrors)
                        .WithStatusCode(HttpStatusCode.BadRequest);
                }

                return HttpStatusCode.Created;
            });
        }
    }
}