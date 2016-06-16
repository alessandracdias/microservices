using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Desobstrucao_Corregos.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace Desobstrucao_Corregos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Coleta_Lixo>("Coletas");
            builder.EntitySet<Construcao_Meio_Fio>("Construcoes");
            builder.EntitySet<Desobstrucao_Corregos>("Corrregos");
            builder.EntitySet<Desobstrucao_Vias_Publicas>("Vias");
            builder.EntitySet<IPTU>("IPTU");
            builder.EntitySet<Poda_Arvore>("Arvores");
            builder.EntitySet<Recolhimento_Carros_Abandonados>("Carros");

            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: builder.GetEdmModel());
        }
    }
}
