using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Funq;
using ServiceStack;
using ServiceStack.Configuration;
using dsnybff.ServiceInterface;
using dsnybff.ServiceModel;

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

    public class AppHost : AppHostBase
    {
        public AppHost() : base("dsnybff", typeof(MyServices).Assembly)
        {
            ServiceStack.Licensing.RegisterLicense(@"6127-e1JlZjo2MTI3LE5hbWU6IkFzdHVjZW1lZGlhLCBJbmMuIixUeXBlOkluZGllLEhhc2g6U0hvclZFS2ZxNGRUREEyY2VrVWVQMnNzTzUzZWxxcXcvUDJ6R1k5TnVkcHpMQThQMjE2bnh3YUpCSWFPOWtYREpBMHNkYmFoVGFZdlhQbEdkRzUySjVYNUpBRkhZbFdOUmRLVFFkRWQ5U29Ib2o4NDE4TVFXVkVxYk9uYWZBdHI4SERKams2RmdyankrU2RPNWY2OXJDNVF4M0piY0hlL2RFSGV0RS83Vk9RPSxFeHBpcnk6MjAxOS0wNS0yNn0=");
        }

        // Configure your AppHost with the necessary configuration and dependencies your App needs
        public override void Configure(Container container)
        {
            base.SetConfig(new HostConfig
            {
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), false)
            });

            Plugins.Add(new TemplatePagesFeature());

            LoadLocations();
            Register(Locations);
        }

        public void LoadLocations()
        {
            Locations = new List<Location>
            {
                new Location {  Code = "wdw", Name = "Walt Disney World",   Topics = "play".Split(',') },
                new Location {  Code = "mk", Name = "Magic Kingdom",        Topics = "play".Split(',') },
                new Location {  Code = "ak", Name = "Animal Kingdom",       Topics = "play".Split(',') },
                new Location {  Code = "hs", Name = "Hollywood Studios",    Topics = "play".Split(',') },
                new Location {  Code = "ep", Name = "Epcot",                Topics = "play".Split(',') },
                new Location {  Code = "tl", Name = "Tyhoon Lagoon",        Topics = "play".Split(',') },
                new Location {  Code = "bb", Name = "Blizzard Beach",       Topics = "play".Split(',') },
                new Location {  Code = "dlr", Name = "Disneyland",          Topics = "play".Split(',') },
                new Location {  Code = "adv", Name = "Adventureland",       Topics = "play".Split(',') },
                new Location {  Code = "vbr", Name = "Vero Beach Resort",   Topics = "sleep,party".Split(',') },
                new Location {  Code = "hh", Name = "Hilton Head",          Topics = "sleep,party".Split(',') },
                new Location {  Code = "par", Name = "Disneyland Paris",    Topics = "play".Split(',') },
                new Location {  Code = "tok", Name = "Disneyland Tokyo",    Topics = "play".Split(',') },
                new Location {  Code = "hk", Name = "Disneyland Hong Kong", Topics = "play".Split(',') },
                new Location {  Code = "shg", Name = "Disneyland Shanghai", Topics = "play".Split(',') },
                new Location {  Code = "py", Name = "Polynesian",           Topics = "sleep,eat".Split(',') },
                new Location {  Code = "gf", Name = "Grand Floridian",      Topics = "sleep,eat".Split(',') },
                new Location {  Code = "dm", Name = "Disney Magic",      Topics = "cruise".Split(',') },
                new Location {  Code = "dw", Name = "Disney Wonder",      Topics = "cruise".Split(',') },
                new Location {  Code = "dd", Name = "Disney Dream",      Topics = "cruise".Split(',') },
                new Location {  Code = "df", Name = "Disney Fantasy",      Topics = "cruise".Split(',') }
            };
        }

        public List<Location> Locations { get; set; }
    }
}
//'/dw': '',
//'/mk': 'Magic Kingdom',
//'/ak': 'Animal Kingdom',
//'/hs': '',
//'/ep': 'Epcot',
//'/tl': 'Typhoon Lagoon',
//'/bb': 'Blizzard Beach',
//'/dl': 'Disneyland',
//'/av': 'Adventure Land',
//'/vb': 'Vero Beach Resort',
//'/hh': 'Hilton Head Resort',
//'/paris': 'Disneyland Paris',
//'/tokyo': 'Disneyland Tokyo',
//'/shanghai': 'Disneyland Shanghai',
//'/hongkong': 'Disneyland HongKong',
