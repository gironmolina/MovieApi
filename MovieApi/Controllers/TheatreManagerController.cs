using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using log4net;
using MovieApi.Application.Dtos;
using MovieApi.Application.Interfaces;
using MovieApi.CrossCutting.Exceptions;

namespace MovieApi.Controllers
{
	public class TheatreManagerController : ApiController
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(ViewerController));
		private readonly ITheatreManagerAppService _theatreManagerAppService;

		/// <summary>Get Upcoming Movies.</summary>
		/// >
		/// <response code="200">Returns Upcoming Movies.</response>
		/// <response code="400">API Bad request.</response>
		/// <response code="500">Server found an unexpected error.</response>
		[HttpGet]
		[Route("api/v1/TheatreManagers/UpcomingMovies")]
		[ResponseType(typeof(IEnumerable<RecommendationMovieDto>))]
		public async Task<IHttpActionResult> GetUpcomingMovies([FromUri] int weeksFromNow, [FromUri] string ageRate,
			[FromUri] string genre)
		{
			try
			{
				var upcomingMovies = await _theatreManagerAppService.GetUpcomingMovies(weeksFromNow, ageRate, genre)
					.ConfigureAwait(false);
				return this.Ok(upcomingMovies);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message, ex);
				if (ex is ViewerException) return BadRequest();

				return InternalServerError(ex);
			}
		}
	}
}