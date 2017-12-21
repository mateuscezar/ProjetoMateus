using System.Web.Http;
using WebActivatorEx;
using Interface;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

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
