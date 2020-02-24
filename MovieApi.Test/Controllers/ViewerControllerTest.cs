using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Results;
using MovieApi.Application.Dtos;
using MovieApi.Controllers;
using MovieApi.Test.Extensions;
using NUnit.Framework;

namespace MovieApi.Test.Controllers
{
	[TestFixture]
	public class ViewerControllerTest
	{
		[Test]
		public async Task GivenUpcomingMoviesQuery_WhenGetUpcomingMovies_ThenShouldReturnExpectedResult()
		{
			//	Arrange
			var controller = TestSetup.Container.GetController<ViewerController>();

			// Act
			var response = await controller.GetUpcomingMovies(new List<string>(), new List<string>(), 1).ConfigureAwait(false);
			var recommendationMovies = (response as OkNegotiatedContentResult<IEnumerable<RecommendationMovieDto>>)?.Content;
			var isSuccessStatusCode = response.ExecuteAsync(new CancellationToken()).Result.IsSuccessStatusCode;

			// Assert
			Assert.IsTrue(isSuccessStatusCode);
			Assert.IsNotNull(recommendationMovies);
			var recommendationMoviesDto = recommendationMovies.ToList();
			Assert.AreEqual(recommendationMoviesDto.ToList().Count, 1);
			Assert.AreEqual(recommendationMoviesDto.First().Genre, "Terror");
			Assert.AreEqual(recommendationMoviesDto.First().Keywords.Count, 2);
			Assert.AreEqual(recommendationMoviesDto.First().Language, "English");
			Assert.AreEqual(recommendationMoviesDto.First().Genre, "Terror");
			Assert.AreEqual(recommendationMoviesDto.First().Overview, "...");
			Assert.AreEqual(recommendationMoviesDto.First().ReleaseDate, new DateTime(1987, 9, 22));
			Assert.AreEqual(recommendationMoviesDto.First().Title, "Best Movie");
			Assert.AreEqual(recommendationMoviesDto.First().WebSite, "www.bestmovie.com");
		}

		[Test]
		public async Task GivenAllTimeMoviesQuery_WhenGetAllTimeMovies_ThenShouldReturnExpectedResult()
		{
			//	Arrange
			var controller = TestSetup.Container.GetController<ViewerController>();

			// Act
			var response = await controller.GetAllTimeMovies(new List<string>(), new List<string>()).ConfigureAwait(false);
			var recommendationMovies = (response as OkNegotiatedContentResult<IEnumerable<RecommendationMovieDto>>)?.Content;
			var isSuccessStatusCode = response.ExecuteAsync(new CancellationToken()).Result.IsSuccessStatusCode;

			// Assert
			Assert.IsTrue(isSuccessStatusCode);
			Assert.IsNotNull(recommendationMovies);
			var recommendationMoviesDto = recommendationMovies.ToList();
			Assert.AreEqual(recommendationMoviesDto.ToList().Count, 1);
			Assert.AreEqual(recommendationMoviesDto.First().Genre, "Terror");
			Assert.AreEqual(recommendationMoviesDto.First().Keywords.Count, 2);
			Assert.AreEqual(recommendationMoviesDto.First().Language, "English");
			Assert.AreEqual(recommendationMoviesDto.First().Genre, "Terror");
			Assert.AreEqual(recommendationMoviesDto.First().Overview, "...");
			Assert.AreEqual(recommendationMoviesDto.First().ReleaseDate, new DateTime(1987, 9, 22));
			Assert.AreEqual(recommendationMoviesDto.First().Title, "Best Movie");
			Assert.AreEqual(recommendationMoviesDto.First().WebSite, "www.bestmovie.com");
		}

		[Test]
		public async Task GivenAllTimeTvShowsQuery_WhenGetAllTimeTvShows_ThenShouldReturnExpectedResult()
		{
			//	Arrange
			var controller = TestSetup.Container.GetController<ViewerController>();

			// Act
			var response = await controller.GetAllTimeTvShows(new List<string>(), new List<string>()).ConfigureAwait(false);
			var recommendationTvShow = (response as OkNegotiatedContentResult<IEnumerable<RecommendationTvShowDto>>)?.Content;
			var isSuccessStatusCode = response.ExecuteAsync(new CancellationToken()).Result.IsSuccessStatusCode;

			// Assert
			Assert.IsTrue(isSuccessStatusCode);
			Assert.IsNotNull(recommendationTvShow);
			var recommendationTvShowDto = recommendationTvShow.ToList();
			Assert.AreEqual(recommendationTvShowDto.ToList().Count, 1);
			Assert.AreEqual(recommendationTvShowDto.First().Genre, "Terror");
			Assert.AreEqual(recommendationTvShowDto.First().Keywords.Count, 2);
			Assert.AreEqual(recommendationTvShowDto.First().Language, "English");
			Assert.AreEqual(recommendationTvShowDto.First().Genre, "Terror");
			Assert.AreEqual(recommendationTvShowDto.First().Overview, "...");
			Assert.AreEqual(recommendationTvShowDto.First().ReleaseDate, new DateTime(1987, 9, 22));
			Assert.AreEqual(recommendationTvShowDto.First().Title, "Best Movie");
			Assert.AreEqual(recommendationTvShowDto.First().WebSite, "www.bestmovie.com");
			Assert.AreEqual(recommendationTvShowDto.First().NumberOfSeasons, 1);
			Assert.AreEqual(recommendationTvShowDto.First().NumberOfEpisodes, 1);
			Assert.AreEqual(recommendationTvShowDto.First().IsConcluded, true);
		}

		[Test]
		public async Task GivenAllTimeDocumentariesQuery_WhenGetAllTimeDocumentaries_ThenShouldReturnExpectedResult()
		{
			//	Arrange
			var controller = TestSetup.Container.GetController<ViewerController>();

			// Act
			var response = await controller.GetAllTimeDocumentaries(new List<string>()).ConfigureAwait(false);
			var recommendationDocumentary = (response as OkNegotiatedContentResult<IEnumerable<RecommendationDocumentaryDto>>)?.Content;
			var isSuccessStatusCode = response.ExecuteAsync(new CancellationToken()).Result.IsSuccessStatusCode;

			// Assert
			Assert.IsTrue(isSuccessStatusCode);
			Assert.IsNotNull(recommendationDocumentary);
			var recommendationDocumentaryDto = recommendationDocumentary.ToList();
			Assert.AreEqual(recommendationDocumentaryDto.ToList().Count, 1);
			Assert.AreEqual(recommendationDocumentaryDto.First().Genre, "Terror");
			Assert.AreEqual(recommendationDocumentaryDto.First().Keywords.Count, 2);
			Assert.AreEqual(recommendationDocumentaryDto.First().Language, "English");
			Assert.AreEqual(recommendationDocumentaryDto.First().Genre, "Terror");
			Assert.AreEqual(recommendationDocumentaryDto.First().Overview, "...");
			Assert.AreEqual(recommendationDocumentaryDto.First().ReleaseDate, new DateTime(1987, 9, 22));
			Assert.AreEqual(recommendationDocumentaryDto.First().Title, "Best Movie");
			Assert.AreEqual(recommendationDocumentaryDto.First().WebSite, "www.bestmovie.com");
		}
	}
}
