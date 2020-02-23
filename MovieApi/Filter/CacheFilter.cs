using System;
using System.Net.Http.Headers;
using System.Web.Http.Filters;

namespace MovieApi.Filter
{
	public class CacheFilter : ActionFilterAttribute
	{
		public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
		{
			actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
			{
				MaxAge = TimeSpan.FromSeconds(100),
				MustRevalidate = true,
				Public = true
			};
		}
	}
}