using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Routing;

namespace StudentApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(corsAttr);
            
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
     
            config.Routes.MapHttpRoute(
                 name: "DefaultApiWithAction",
                 routeTemplate: "api/{controller}/{action}",
                 defaults: new { controller = "Course", StudentID = RouteParameter.Optional, CourseID = RouteParameter.Optional }
             );
            config.Routes.MapHttpRoute(
                name: "ApiGetWithID", 
                routeTemplate: "Api/{controller}/{id}", 
                defaults: new { action = "Get", id = RouteParameter.Optional }, new { id = @"\d+" }
                );
            config.Routes.MapHttpRoute(
                name: "StudentApiGet",
                routeTemplate: "Api/{controller}/{action}/{id}",
                defaults: new { controller = "students", action = "Get" , id= RouteParameter.Optional }, 
                          new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) }
                );
            
        }
    }
}

