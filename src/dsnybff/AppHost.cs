using System.Collections.Generic;
using Funq;
using ServiceStack;
using ServiceStack.Script;
using ServiceStack.Text;
using dsnybff.ServiceInterface;
using dsnybff.ServiceModel;

namespace dsnybff
{
    public class AppHost : AppHostBase
    {
        public AppHost() : base("dsnybff", typeof(MyServices).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            base.SetConfig(new HostConfig
            {
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), false)
            });

            Plugins.Add(new SharpPagesFeature()
            {
                PageFormats = {
                    new HtmlPageFormat(),
                    new MarkdownPageFormat(){
                        ArgsPrefix = "<!--",
                        ArgsSuffix = "-->",
                    } }
            });

            JsConfig.DateHandler = DateHandler.ISO8601;
            JsConfig.TimeSpanHandler = TimeSpanHandler.StandardFormat;
            JsConfig.ExcludeTypeInfo = true;

            this.ReloadCsv<Location>();
            this.ReloadCsv<Post>();
        }

        public void LoadLocations()
        {
            Locations = "wwwroot/data/locations.csv"
                .MapHostAbsolutePath()
                .ReadAllText().FromCsv<List<Location>>();
        }

        public void LoadPosts()
        {
            Posts = "wwwroot/data/posts.csv"
                .MapHostAbsolutePath()
                .ReadAllText().FromCsv<List<Post>>();
        }

        public List<Location> Locations { get; set; }
        public List<Post> Posts { get; set; }
    }
}
