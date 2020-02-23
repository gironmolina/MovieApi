using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Domain.Interfaces;
using MovieApi.Entities;

namespace MovieApi.Domain.Services
{
	public class TheatreManagerService : ITheatreManagerService
	{
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
					ReleaseDate = DateTime.Now,
					WebSite = "www.bestmovie.com",
					Keywords = new List<string>{"movie", "best"}
				}
			};
			return await Task.FromResult<IEnumerable<RecommendationMovieEntity>>(upcomingMovies);
		}

		public async Task<IEnumerable<BillboardEntity>> GetSuggestedBillboard(int weeksFromNow, int numberOfScreens, bool basedOnCityMovies)
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
								ReleaseDate = DateTime.Now,
								WebSite = "www.bestmovie.com",
								Keywords = new List<string>{"movie", "best"}
							},
							Screen = 1
						}
					},
					WeekStart = DateTime.Now
				}
			};
			return await Task.FromResult<IEnumerable<BillboardEntity>>(billboard);
		}
	}
}
