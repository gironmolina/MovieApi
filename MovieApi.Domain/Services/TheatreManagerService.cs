using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using log4net;
using MovieApi.Domain.Interfaces;
using MovieApi.Entities;
using MovieApi.Infrastructure.Interfaces;

namespace MovieApi.Domain.Services
{
	public class TheatreManagerService : ITheatreManagerService
	{
		private static readonly ILog Logger = LogManager.GetLogger(typeof(TheatreManagerService));
		private readonly IMoviesRepository _moviesRepository;
		private readonly IWeekBoardService _weekBoardService;
		private const int MIN_WEEKS_FROM_NOW = 1;
		private const int MAX_WEEKS_FROM_NOW = 52;
		private const int MIN_SCREENS = 0;
		private const int MAX_SCREENS = 30;

		public TheatreManagerService(
			IMoviesRepository moviesRepository,
			IWeekBoardService weekBoardService)
		{
			_moviesRepository = moviesRepository;
			_weekBoardService = weekBoardService;
		}

		public async Task<IEnumerable<RecommendationMovieEntity>> GetUpcomingMovies(int weeksFromNow, string ageRate, string genre)
		{
			var upcomingMovies = new List<RecommendationMovieEntity>
			{
				new RecommendationMovieEntity
				{
					Title = "Best Movie",
					Overview = "...",
					Genre = "Terror",
					Language = "English",
					ReleaseDate = new DateTime(1987, 9, 22),
					WebSite = "www.bestmovie.com",
					Keywords = new List<string>{"movie", "best"}
				}
			};
			return await Task.FromResult<IEnumerable<RecommendationMovieEntity>>(upcomingMovies);
		}

		public async Task<IEnumerable<BillboardEntity>> GetSuggestedBillboard(int weeksFromNow, int numberOfScreens, bool isBasedOnCityMovies)
		{
			var billboard = new List<BillboardEntity>
			{
				new BillboardEntity
				{
					MovieScreen = new List<MovieScreenEntity>
					{
						new MovieScreenEntity
						{
							Movie = new RecommendationMovieEntity
							{
								Title = "Best Movie",
								Overview = "...",
								Genre = "Terror",
								Language = "English",
								ReleaseDate = new DateTime(1987, 9, 22),
								WebSite = "www.bestmovie.com",
								Keywords = new List<string>{"movie", "best"}
							},
							Screen = 1
						}
					},
					WeekStart = new DateTime(1987, 9, 22)
				}
			};
			return await Task.FromResult<IEnumerable<BillboardEntity>>(billboard);
		}

		public async Task<IEnumerable<IntelligentBillboardEntity>> GetIntelligentBillboard(
			int weeksFromNow, 
			int numberOfBigScreens, 
			int numberOfSmallScreens,
			bool isBasedOnCityMovies)
		{
			ValidateBillboardQuery(weeksFromNow, numberOfBigScreens, numberOfSmallScreens);
			var moviesInfo = isBasedOnCityMovies ?
				await _moviesRepository.GetMoviesInfoFromDb() : 
				await _moviesRepository.GetMoviesInfoFromApi();

			var weekBoards = _weekBoardService.GetWeekBoardsFromMoviesInfo(
				moviesInfo, weeksFromNow, numberOfBigScreens, numberOfSmallScreens);

			var intelligentBillboard = 
				weekBoards.Select(weekBoard => new IntelligentBillboardEntity
				{
					WeekStart = weekBoard.WeekStart,
					BigScreensMovies = Mapper.Map<List<MovieScreenEntity>>(weekBoard.BigScreenBoard), 
					SmallScreensMovies = Mapper.Map<List<MovieScreenEntity>>(weekBoard.SmallScreenBoard)
				}).ToList();

			return intelligentBillboard;
		}

		private void ValidateBillboardQuery(int weeksFromNow, int numberOfBigScreens, int numberOfSmallScreens)
		{
			ValidateWeeksFromNow(weeksFromNow);
			ValidateBigRoomsScreensNumber(numberOfBigScreens);
			ValidateSmallRoomsScreensNumber(numberOfSmallScreens);
			ValidateTotalRoomsScreensNumber(numberOfBigScreens, numberOfSmallScreens);
		}

		private void ValidateWeeksFromNow(int weeksFromNow)
		{
			if (weeksFromNow >= MIN_WEEKS_FROM_NOW && weeksFromNow <= MAX_WEEKS_FROM_NOW) return;
			var errorMessage = $"Weeks must be between {MIN_WEEKS_FROM_NOW} and {MAX_WEEKS_FROM_NOW}";
			Logger.Error(errorMessage);
			throw new ArgumentException(errorMessage);
		}

		private void ValidateBigRoomsScreensNumber(int numberOfBigScreens)
		{
			if (numberOfBigScreens >= MIN_SCREENS && numberOfBigScreens <= MAX_SCREENS) return;
			var errorMessage = $"Number of big rooms must be between {MIN_SCREENS} and {MAX_SCREENS}";
			Logger.Error(errorMessage);
			throw new ArgumentException(errorMessage);
		}

		private void ValidateSmallRoomsScreensNumber(int numberOfSmallScreens)
		{
			if (numberOfSmallScreens >= MIN_SCREENS && numberOfSmallScreens <= MAX_SCREENS) return;
			var errorMessage = $"Number of small rooms must be between {MIN_SCREENS} and {MAX_SCREENS}";
			Logger.Error(errorMessage);
			throw new ArgumentException(errorMessage);
		}

		private void ValidateTotalRoomsScreensNumber(int numberOfBigScreens, int numberOfSmallScreens)
		{
			if (numberOfBigScreens + numberOfSmallScreens > MIN_SCREENS) return;
			var errorMessage = $"Total number of rooms must be greater than {MIN_SCREENS}";
			Logger.Error(errorMessage);
			throw new ArgumentException(errorMessage);
		}
	}
}
