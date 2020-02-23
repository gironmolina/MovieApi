using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using log4net;
using MovieApi.Application.Dtos;
using MovieApi.Application.Interfaces;
using MovieApi.Domain.Interfaces;

namespace MovieApi.Application.Services
{
	public class TheatreManagerAppService : ITheatreManagerAppService
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(TheatreManagerAppService));
		private readonly ITheatreManagerService _theatreManagerService;

		public TheatreManagerAppService(ITheatreManagerService theatreManagerService)
		{
			_theatreManagerService = theatreManagerService;
		}

		public async Task<IEnumerable<RecommendationMovieDto>> GetUpcomingMovies(int weeksFromNow, string ageRate, string genre)
		{
			Logger.Debug("Getting Upcoming Movies");
			var upcomingMovies = await this._theatreManagerService.GetUpcomingMovies(weeksFromNow, ageRate, genre).ConfigureAwait(false);
			return Mapper.Map<IEnumerable<RecommendationMovieDto>>(upcomingMovies);
		}

		public async Task<IEnumerable<BillboardDto>> GetSuggestedBillboard(int weeksFromNow, int numberOfScreens, bool basedOnCityMovies)
		{
			Logger.Debug("Getting Suggested Billboard");
			var upcomingMovies = await this._theatreManagerService.GetSuggestedBillboard(weeksFromNow, numberOfScreens, basedOnCityMovies).ConfigureAwait(false);
			return Mapper.Map<IEnumerable<BillboardDto>>(upcomingMovies);
		}
	}
}
