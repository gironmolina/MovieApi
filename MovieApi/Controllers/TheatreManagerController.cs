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
	/// <summary>
	/// TheatreManager Controller
	/// </summary>
	public class TheatreManagerController : ApiController
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(ViewerController));
		private readonly ITheatreManagerAppService _theatreManagerAppService;

		/// <summary>
		/// TheatreManagerController
		/// </summary>
		/// <param name="theatreManagerAppService"></param>
		public TheatreManagerController(ITheatreManagerAppService theatreManagerAppService)
		{
			_theatreManagerAppService = theatreManagerAppService;
		}

		/// <summary>Get Upcoming Movies.</summary>
		/// <response code="200">Returns Upcoming Movies.</response>
		/// <response code="400">API Bad request.</response>
		/// <response code="500">Server found an unexpected error.</response>
		[HttpGet]
		[Route("api/v1/TheatreManager/UpcomingMovies")]
		[ResponseType(typeof(IEnumerable<RecommendationMovieDto>))]
		public async Task<IHttpActionResult> GetUpcomingMovies([FromUri] int weeksFromNow, [FromUri] string ageRate, [FromUri] string genre)
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
				if (ex is ManagerTheatreException)
				{
					return BadRequest();
				}

				return InternalServerError(ex);
			}
		}

		/// <summary>Get Suggested Billboard.</summary>
		/// <response code="200">Returns Suggested Billboard.</response>
		/// <response code="400">API Bad request.</response>
		/// <response code="500">Server found an unexpected error.</response>
		[HttpGet]
		[Route("api/v1/TheatreManager/SuggestedBillboard")]
		[ResponseType(typeof(IEnumerable<BillboardDto>))]
		public async Task<IHttpActionResult> GetSuggestedBillboard([FromUri] int weeksFromNow, [FromUri] int numberOfScreens, [FromUri] bool basedOnCityMovies)
		{
			try
			{
				var suggestedBillboard = await _theatreManagerAppService.GetSuggestedBillboard(weeksFromNow, numberOfScreens, basedOnCityMovies)
					.ConfigureAwait(false);
				return this.Ok(suggestedBillboard);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message, ex);
				if (ex is ManagerTheatreException)
				{
					return BadRequest();
				}

				return InternalServerError(ex);
			}
		}

		///// <summary>Get Upcoming Movies.</summary>
		///// >
		///// <response code="200">Returns Upcoming Movies.</response>
		///// <response code="400">API Bad request.</response>
		///// <response code="500">Server found an unexpected error.</response>
		//[HttpGet]
		//[Route("api/v1/TheatreManagers/UpcomingMovies")]
		//[ResponseType(typeof(IEnumerable<RecommendationMovieDto>))]
		//public async Task<IHttpActionResult> GetIntelligentBillboard(
		//	[FromUri] int weeksFromNow, 
		//	[FromUri] int numberOfBigScreens, 
		//	[FromUri] int numberOfSmallScreens,
		//	[FromUri] bool basedOnCityMovies)
		//{
		//	try
		//	{
		//		var upcomingMovies = await _theatreManagerAppService.GetUpcomingMovies(weeksFromNow, ageRate, genre)
		//			.ConfigureAwait(false);
		//		return this.Ok(upcomingMovies);
		//	}
		//	catch (Exception ex)
		//	{
		//		Logger.Error(ex.Message, ex);
		//		if (ex is ViewerException) return BadRequest();

		//		return InternalServerError(ex);
		//	}
		//}
	}
}