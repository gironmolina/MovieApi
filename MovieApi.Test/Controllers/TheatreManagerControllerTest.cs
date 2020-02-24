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
	public class TheatreManagerControllerTest
	{
		[Test]
		public async Task GivenUpcomingMoviesQuery_WhenGetUpcomingMovies_ThenShouldReturnExpectedResult()
		{
			//	Arrange
		   var controller = TestSetup.Container.GetController<TheatreManagerController>();

			// Act
			var response = await controller.GetUpcomingMovies(1, "", "").ConfigureAwait(false);
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
		public async Task GivenSuggestedBillboardQuery_WhenGetSuggestedBillboard_ThenShouldReturnExpectedResult()
		{
			//	Arrange
			var controller = TestSetup.Container.GetController<TheatreManagerController>();

			// Act
			var response = await controller.GetSuggestedBillboard(1, 1, true).ConfigureAwait(false);
			var suggestedBillboard = (response as OkNegotiatedContentResult<IEnumerable<BillboardDto>>)?.Content;
			var isSuccessStatusCode = response.ExecuteAsync(new CancellationToken()).Result.IsSuccessStatusCode;

			// Assert
			Assert.IsTrue(isSuccessStatusCode);
			Assert.IsNotNull(suggestedBillboard);
			var suggestedBillboardDto = suggestedBillboard.ToList();
			Assert.AreEqual(suggestedBillboardDto.ToList().Count, 1);
			Assert.AreEqual(suggestedBillboardDto.First().WeekStart, new DateTime(1987, 9, 22));
			Assert.AreEqual(suggestedBillboardDto.First().MovieScreen.Count, 1);
			Assert.AreEqual(suggestedBillboardDto.First().MovieScreen.First().Screen, 1);
			Assert.AreEqual(suggestedBillboardDto.First().MovieScreen.First().Movie.Genre, "Terror");
			Assert.AreEqual(suggestedBillboardDto.First().MovieScreen.First().Movie.Keywords.Count, 2);
			Assert.AreEqual(suggestedBillboardDto.First().MovieScreen.First().Movie.Language, "English");
			Assert.AreEqual(suggestedBillboardDto.First().MovieScreen.First().Movie.Genre, "Terror");
			Assert.AreEqual(suggestedBillboardDto.First().MovieScreen.First().Movie.Overview, "...");
			Assert.AreEqual(suggestedBillboardDto.First().MovieScreen.First().Movie.ReleaseDate, new DateTime(1987, 9, 22));
			Assert.AreEqual(suggestedBillboardDto.First().MovieScreen.First().Movie.Title, "Best Movie");
			Assert.AreEqual(suggestedBillboardDto.First().MovieScreen.First().Movie.WebSite, "www.bestmovie.com");
		}

		[Test]
		public async Task GivenIntelligentBillboardQueryWithIsBaseOnCityMoviesTrue_WhenGetIntelligentBillboard_ThenShouldReturnExpectedResult()
		{
			//	Arrange
			var controller = TestSetup.Container.GetController<TheatreManagerController>();

			// Act
			var response = await controller.GetIntelligentBillboard(1, 1, 1, true).ConfigureAwait(false);
			var intelligentBillboard = (response as OkNegotiatedContentResult<IEnumerable<IntelligentBillboardDto>>)?.Content;
			var isSuccessStatusCode = response.ExecuteAsync(new CancellationToken()).Result.IsSuccessStatusCode;

			// Assert
			Assert.IsTrue(isSuccessStatusCode);
			Assert.IsNotNull(intelligentBillboard);
			var intelligentBillboardDto = intelligentBillboard.ToList();
			Assert.AreEqual(intelligentBillboardDto.ToList().Count, 1);
			Assert.AreEqual(intelligentBillboardDto.First().BigScreensMovies.Count, 1);
			Assert.AreEqual(intelligentBillboardDto.First().BigScreensMovies.First().Screen, 1);
			Assert.AreEqual(intelligentBillboardDto.First().BigScreensMovies.First().Movie.Genre, "Crime");
			Assert.AreEqual(intelligentBillboardDto.First().BigScreensMovies.First().Movie.Keywords.Count, 0);
			Assert.AreEqual(intelligentBillboardDto.First().BigScreensMovies.First().Movie.Language, "en");
			Assert.AreEqual(intelligentBillboardDto.First().BigScreensMovies.First().Movie.Overview, "");
			Assert.AreEqual(intelligentBillboardDto.First().BigScreensMovies.First().Movie.ReleaseDate, new DateTime(2017, 2, 10));
			Assert.AreEqual(intelligentBillboardDto.First().BigScreensMovies.First().Movie.Title, "John Wick: Chapter 2");
			Assert.AreEqual(intelligentBillboardDto.First().BigScreensMovies.First().Movie.WebSite, "");

			Assert.AreEqual(intelligentBillboardDto.First().SmallScreensMovies.Count, 1);
			Assert.AreEqual(intelligentBillboardDto.First().SmallScreensMovies.First().Screen, 1);
			Assert.AreEqual(intelligentBillboardDto.First().SmallScreensMovies.First().Movie.Genre, "Crime");
			Assert.AreEqual(intelligentBillboardDto.First().SmallScreensMovies.First().Movie.Keywords.Count, 0);
			Assert.AreEqual(intelligentBillboardDto.First().SmallScreensMovies.First().Movie.Language, "fr");
			Assert.AreEqual(intelligentBillboardDto.First().SmallScreensMovies.First().Movie.Overview, "");
			Assert.AreEqual(intelligentBillboardDto.First().SmallScreensMovies.First().Movie.ReleaseDate, new DateTime(1994, 11, 18));
			Assert.AreEqual(intelligentBillboardDto.First().SmallScreensMovies.First().Movie.Title, "Léon");
			Assert.AreEqual(intelligentBillboardDto.First().SmallScreensMovies.First().Movie.WebSite, "");
		}

		[Test]
		public async Task GivenIntelligentBillboardQueryWithIsBaseOnCityMoviesFalse_WhenGetIntelligentBillboard_ThenShouldReturnExpectedResult()
		{
			//	Arrange
			var controller = TestSetup.Container.GetController<TheatreManagerController>();

			// Act
			var response = await controller.GetIntelligentBillboard(1, 1, 1, false).ConfigureAwait(false);
			var intelligentBillboard = (response as OkNegotiatedContentResult<IEnumerable<IntelligentBillboardDto>>)?.Content;
			var isSuccessStatusCode = response.ExecuteAsync(new CancellationToken()).Result.IsSuccessStatusCode;

			// Assert
			Assert.IsTrue(isSuccessStatusCode);
			Assert.IsNotNull(intelligentBillboard);
			var intelligentBillboardDto = intelligentBillboard.ToList();
			Assert.AreEqual(intelligentBillboardDto.ToList().Count, 1);
			Assert.AreEqual(intelligentBillboardDto.First().BigScreensMovies.Count, 1);
			Assert.AreEqual(intelligentBillboardDto.First().SmallScreensMovies.Count, 1);
		}
	}
}
