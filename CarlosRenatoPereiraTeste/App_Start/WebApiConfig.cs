using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CarlosRenatoPereiraTeste
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.EnableSwagger("swaggerDocs", c =>
            {
                c.SingleApiVersion("v1", "CarlosRenatoPereiraTeste API");
            })
.EnableSwaggerUi("swaggerUi");
        }
        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\CarlosRenatoPereiraTeste.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
