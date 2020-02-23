using System.Web.Http;
using WebActivatorEx;
using MovieApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MovieApi
{
	public class SwaggerConfig
	{
		public static void Register()
		{
			var thisAssembly = typeof(SwaggerConfig).Assembly;

			GlobalConfiguration.Configuration
				.EnableSwagger(c =>
				{
					c.SingleApiVersion("v1", "Movie API");
					c.IncludeXmlComments($@"{System.AppDomain.CurrentDomain.BaseDirectory}\bin\MovieApi.API.XML");
				})
				.EnableSwaggerUi();
		}
	}
}
