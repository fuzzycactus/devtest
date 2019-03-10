using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Funq;
using ServiceStack;
using ServiceStack.Configuration;

namespace dsnybff
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ServiceStack.Licensing.RegisterLicense(@"6127-e1JlZjo2MTI3LE5hbWU6IkFzdHVjZW1lZGlhLCBJbmMuIixUeXBlOkluZGllLEhhc2g6U0hvclZFS2ZxNGRUREEyY2VrVWVQMnNzTzUzZWxxcXcvUDJ6R1k5TnVkcHpMQThQMjE2bnh3YUpCSWFPOWtYREpBMHNkYmFoVGFZdlhQbEdkRzUySjVYNUpBRkhZbFdOUmRLVFFkRWQ5U29Ib2o4NDE4TVFXVkVxYk9uYWZBdHI4SERKams2RmdyankrU2RPNWY2OXJDNVF4M0piY0hlL2RFSGV0RS83Vk9RPSxFeHBpcnk6MjAxOS0wNS0yNn0=");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseServiceStack(new AppHost
            {
                AppSettings = new NetCoreAppSettings(Configuration)
            });
        }
    }
}

