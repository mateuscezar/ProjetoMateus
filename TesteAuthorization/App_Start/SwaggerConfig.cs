using System.Web.Http;
using WebActivatorEx;
using Interface;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;
using Interface.App_Start;

namespace Interface
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Interface");
                        c.PrettyPrint();
                        c.IncludeXmlComments(GetXmlCommentsPath());
                        c.OperationFilter<AddAuthorizationHeader>();
                        //c.BasicAuth("Bearer HGkjO8psQXeAJoRU3lCv42xnFehSjZyqTr7b-5n2YCUAvP0QheePgahqTPlZiWvsgkvlZHvPBuhhraFzIhh7KWRvwvpvQH-6Lt2SsarLuVgmOIyVTb1BRNnBLgdnG6DTn9jaFb_IMlRX6smUO3aw4BFFqGou9opFEJdR9cGOY5iY4pBzj3OxtcfVlLnFzpiCv2KhTXXnHimjQVNT3AXbH-ZNK0Np5gV5eX5dpARHbXE");
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }

        private static string GetXmlCommentsPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"\bin\Interface.xml";
        }
    }
}
