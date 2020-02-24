using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using MovieApi.CrossCutting.Interfaces;
using MovieApi.Entities;
using MovieApi.Entities.Enums;
using MovieApi.Infrastructure.Interfaces;

namespace MovieApi.Infrastructure.Repositories
{
	public class MoviesRepository : IMoviesRepository
	{
		private readonly IAppConfigSettings _appConfigSettings;

		public MoviesRepository(IAppConfigSettings appConfigSettings)
		{
			_appConfigSettings = appConfigSettings;
		}

		public async Task<List<MovieInfoEntity>> GetMoviesInfoFromDb()
		{
			return new List<MovieInfoEntity>();
		}

		public async Task<List<MovieInfoEntity>> GetMoviesInfoFromApi()
		{
			var bigMovies = await _appConfigSettings.DiscoverMovieUrl
				.SetQueryParams(new
				{
					api_key = _appConfigSettings.ApiKey,
					sort_by = _appConfigSettings.SortBy,
					include_adult = false,
					include_video = false,
					page = 1
				})
				.GetJsonAsync();

			var smallMovies = await _appConfigSettings.DiscoverMovieUrl
				.SetQueryParams(new
				{
					api_key = _appConfigSettings.ApiKey,
					sort_by = _appConfigSettings.SortBy,
					include_adult = false,
					include_video = false,
					page = 2
				})
				.GetJsonAsync();

			var genres = await _appConfigSettings.GenreListUrl
				.SetQueryParams(new
				{
					api_key = _appConfigSettings.ApiKey,
				})
				.GetJsonAsync();

			Dictionary<long, string> genresDictionary = SetGenres(genres);

			var moviesInfoFromApi = GetMoviesInfoList(bigMovies, smallMovies, genresDictionary);
			return moviesInfoFromApi;
		}
		
		private string GetGenre(int id, List<MovieGenreEntity> moviesGenres, List<GenreEntity> genres)
		{
			var genreId = moviesGenres.FirstOrDefault(mg => mg.MovieId == id)?.GenreId;
			return genres.FirstOrDefault(g => g.Id == genreId)?.Name;
		}

		private RoomSizeType GetRoomSizeType(string size)
		{
			return size?.ToLower() == "small" ? RoomSizeType.Small : RoomSizeType.Big;
		}

		private List<MovieInfoEntity> GetMoviesInfoList(dynamic bigMovies, dynamic smallMovies, Dictionary<long, string> genresDictionary)
		{
			var movies = new List<MovieInfoEntity>();

			foreach (var movie in bigMovies.results)
			{
				movies.Add(ConvertToMovieInfo(movie, genresDictionary, RoomSizeType.Big));
			}

			foreach (var movie in smallMovies.results)
			{
				movies.Add(ConvertToMovieInfo(movie, genresDictionary, RoomSizeType.Small));
			}
			return movies;
		}

		private MovieInfoEntity ConvertToMovieInfo(dynamic movie, Dictionary<long, string> genres, RoomSizeType roomSize)
		{
			string title = movie.title;
			string overview = movie.overview;
			string movieGenre = movie.genre_ids.Count > 0 ? genres[movie.genre_ids[0]] : null;
			string original_language = movie.original_language;
			DateTime release_date = DateTime.ParseExact(movie.release_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

			return new MovieInfoEntity(title, overview, movieGenre, original_language, release_date, string.Empty, new List<string>(), roomSize, 0);
		}

		private Dictionary<long, string> SetGenres(dynamic genres)
		{
			Dictionary<long, string> genresDictionary = new Dictionary<long, string>();

			foreach (var genre in genres.genres)
			{
				genresDictionary.Add(genre.id, genre.name);
			}

			return genresDictionary;
		}
	}
}
