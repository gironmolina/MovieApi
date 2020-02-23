using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using log4net;
using MovieApi.Application.Dtos;
using MovieApi.Application.Interfaces;
using MovieApi.Domain.Interfaces;

namespace MovieApi.Application.Services
{
	public class ViewerAppService : IViewerAppService
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(IViewerAppService));
		private readonly IViewerService _viewerService;

		public ViewerAppService(IViewerService viewerService)
		{
			_viewerService = viewerService;
		}

		public async Task<IEnumerable<RecommendationMovieDto>> GetUpcomingMovies(List<string> keywords, List<string> genres, int weeksFromNow)
		{
			Logger.Debug("Getting Upcoming Movies");
			var upcomingMovies = await this._viewerService.GetUpcomingMovies(keywords, genres, weeksFromNow).ConfigureAwait(false);
			return Mapper.Map<IEnumerable<RecommendationMovieDto>>(upcomingMovies);
		}

		public async Task<IEnumerable<RecommendationMovieDto>> GetAllTimeMovies(List<string> keywords, List<string> genres)
		{
			Logger.Debug("Getting All Time Movies");
			var allTimeMovies = await this._viewerService.GetAllTimeMovies(keywords, genres).ConfigureAwait(false);
			return Mapper.Map<IEnumerable<RecommendationMovieDto>>(allTimeMovies);
		}

		public async Task<IEnumerable<RecommendationTvShowDto>> GetAllTimeTvShows(List<string> keywords, List<string> genres)
		{
			Logger.Debug("Getting All Time Tv Shows");
			var allTimeTvShows = await this._viewerService.GetAllTimeTvShows(keywords, genres).ConfigureAwait(false);
			return Mapper.Map<IEnumerable<RecommendationTvShowDto>>(allTimeTvShows);
		}

		public async Task<IEnumerable<RecommendationDocumentaryDto>> GetAllTimeDocumentaries(List<string> topics)
		{
			Logger.Debug("Getting All Time Documentaries");
			var allTimeDocumentaries = await this._viewerService.GetAllTimeDocumentaries(topics).ConfigureAwait(false);
			return Mapper.Map<IEnumerable<RecommendationDocumentaryDto>>(allTimeDocumentaries);
		}
	}
}
