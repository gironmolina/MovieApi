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
	/// Viewer Controller
	/// </summary>
	public class ViewerController : ApiController
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(ViewerController));
		private readonly IViewerAppService _viewerAppService;

		/// <summary>
		/// ViewerController
		/// </summary>
		/// <param name="viewerAppService"></param>
		public ViewerController(IViewerAppService viewerAppService)
		{
			this._viewerAppService = viewerAppService;
		}

		/// <summary>Get Upcoming Movies.</summary>>
		/// <response code="200">Returns Upcoming Movies.</response>
		/// <response code="400">API Bad request.</response>
		/// <response code="500">Server found an unexpected error.</response>
		[HttpGet]
		[Route("api/v1/UpcomingMovies")]
		[ResponseType(typeof(IEnumerable<RecommendationMovieDto>))]
		public async Task<IHttpActionResult> GetUpcomingMovies([FromUri] List<string> keywords, [FromUri] List<string> genres, [FromUri] int weeksFromNow)
		{
			try
			{
				var upcomingMovies = await this._viewerAppService.GetUpcomingMovies(keywords, genres, weeksFromNow)
					.ConfigureAwait(false);
				return this.Ok(upcomingMovies);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message, ex);
				if (ex is ViewerException)
				{
					return BadRequest();
				}

				return InternalServerError(ex);
			}
		}

		/// <summary>Get All Time Movies.</summary>>
		/// <response code="200">Returns Get All Time Movie.</response>
		/// <response code="400">API Bad request.</response>
		/// <response code="500">Server found an unexpected error.</response>
		[HttpGet]
		[Route("api/v1/AllTimeMovies")]
		[ResponseType(typeof(IEnumerable<RecommendationMovieDto>))]
		public async Task<IHttpActionResult> GetAllTimeMovies([FromUri] List<string> keywords, [FromUri] List<string> genres)
		{
			try
			{
				var response = await this._viewerAppService.GetAllTimeMovies(keywords, genres)
					.ConfigureAwait(false);
				return this.Ok(response);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message, ex);
				if (ex is ViewerException)
				{
					return BadRequest();
				}

				return InternalServerError(ex);
			}
		}

		/// <summary>Get All Time Tv Shows.</summary>>
		/// <response code="200">Returns Get All Time Tv Shows.</response>
		/// <response code="400">API Bad request.</response>
		/// <response code="500">Server found an unexpected error.</response>
		[HttpGet]
		[Route("api/v1/AllTimeTVShows")]
		[ResponseType(typeof(IEnumerable<RecommendationTvShowDto>))]
		public async Task<IHttpActionResult> GetAllTimeTvShows([FromUri] List<string> keywords, [FromUri] List<string> genres)
		{
			try
			{
				var response = await this._viewerAppService.GetAllTimeTvShows(keywords, genres)
					.ConfigureAwait(false);
				return this.Ok(response);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message, ex);
				if (ex is ViewerException)
				{
					return BadRequest();
				}

				return InternalServerError(ex);
			}
		}

		/// <summary>Get All Time Documentaries.</summary>>
		/// <response code="200">Returns Get All Time Documentaries.</response>
		/// <response code="400">API Bad request.</response>
		/// <response code="500">Server found an unexpected error.</response>
		[HttpGet]
		[Route("api/v1/AllTimeDocumentaries")]
		[ResponseType(typeof(IEnumerable<RecommendationDocumentaryDto>))]
		public async Task<IHttpActionResult> GetAllTimeDocumentaries([FromUri] List<string> topics)
		{
			try
			{
				var response = await this._viewerAppService.GetAllTimeDocumentaries(topics)
					.ConfigureAwait(false);
				return this.Ok(response);
			}
			catch (Exception ex)
			{
				Logger.Error(ex.Message, ex);
				if (ex is ViewerException)
				{
					return BadRequest();
				}

				return InternalServerError(ex);
			}
		}
	}
}