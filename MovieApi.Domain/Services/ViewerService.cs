using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Domain.Interfaces;
using MovieApi.Entities;

namespace MovieApi.Domain.Services
{
	public class ViewerService : IViewerService
	{
		public async Task<IEnumerable<RecommendationMovieEntity>> GetUpcomingMovies(List<string> keywords, List<string> genres, int weeksFromNow)
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

		public async Task<IEnumerable<RecommendationMovieEntity>> GetAllTimeMovies(List<string> keywords, List<string> genres)
		{
			var allTimeMovies = new List<RecommendationMovieEntity>
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
			return await Task.FromResult<IEnumerable<RecommendationMovieEntity>>(allTimeMovies);
		}

		public async Task<IEnumerable<RecommendationTvShowEntity>> GetAllTimeTvShows(List<string> keywords, List<string> genres)
		{
			var allTimeTvShows = new List<RecommendationTvShowEntity>
			{
				new RecommendationTvShowEntity
				{
					Title = "Best Movie",
					Overview = "...",
					Genre = "Terror",
					Language = "English",
					ReleaseDate = new DateTime(1987, 9, 22),
					WebSite = "www.bestmovie.com",
					Keywords = new List<string>{"movie", "best"},
					NumberOfSeasons = 1,
					NumberOfEpisodes = 1,
					IsConcluded = true
				}
			};
			return await Task.FromResult<IEnumerable<RecommendationTvShowEntity>>(allTimeTvShows);
		}

		public async Task<IEnumerable<RecommendationDocumentaryEntity>> GetAllTimeDocumentaries(List<string> topics)
		{
			var allTimeDocumentaries = new List<RecommendationDocumentaryEntity>
			{
				new RecommendationDocumentaryEntity
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
			return await Task.FromResult<IEnumerable<RecommendationDocumentaryEntity>>(allTimeDocumentaries);
		}
	}
}
