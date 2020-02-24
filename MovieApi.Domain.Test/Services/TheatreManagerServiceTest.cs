using System;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Domain.Interfaces;
using MovieApi.Domain.Services;
using MovieApi.Infrastructure.Interfaces;
using NUnit.Framework;
using Rhino.Mocks;

namespace MovieApi.Domain.Test.Services
{
	[TestFixture]
	public class TheatreManagerServiceTest
	{
		private TheatreManagerService _sut;

		[SetUp]
		public void SetUp()
		{
			var moviesRepository = MockRepository.GenerateMock<IMoviesRepository>();
			var weekBoardService = MockRepository.GenerateMock<IWeekBoardService>();
			_sut = new TheatreManagerService(moviesRepository, weekBoardService);
		}

		[Test]
		public async Task GivenUpcomingMoviesParams_WhenGetUpcomingMovies_ThenShouldReturnExpectedValues()
		{
			// Arrange
			var weeksFromNow = 1;

			// Act
			var result = await _sut.GetUpcomingMovies(weeksFromNow, "", "").ConfigureAwait(false);

			// Assert
			Assert.IsNotNull(result);
			var upcomingMovies = result.ToList();
			Assert.AreEqual(upcomingMovies.ToList().Count, 1);
			Assert.AreEqual(upcomingMovies.First().Genre, "Terror");
			Assert.AreEqual(upcomingMovies.First().Keywords.Count, 2);
			Assert.AreEqual(upcomingMovies.First().Language, "English");
			Assert.AreEqual(upcomingMovies.First().Genre, "Terror");
			Assert.AreEqual(upcomingMovies.First().Overview, "...");
			Assert.AreEqual(upcomingMovies.First().ReleaseDate, new DateTime(1987, 9, 22));
			Assert.AreEqual(upcomingMovies.First().Title, "Best Movie");
			Assert.AreEqual(upcomingMovies.First().WebSite, "www.bestmovie.com");
		}

		[Test]
		public async Task GivenSuggestedBillboardParams_WhenGetSuggestedBillboard_ThenShouldReturnExpectedValues()
		{
			// Arrange
			var weeksFromNow = 1;
			var numberOfScreens = 1;

			// Act
			var result = await _sut.GetSuggestedBillboard(weeksFromNow, numberOfScreens, true).ConfigureAwait(false);

			// Assert
			Assert.IsNotNull(result);
			var suggestedBillboard = result.ToList();
			Assert.AreEqual(suggestedBillboard.ToList().Count, 1);
			Assert.AreEqual(suggestedBillboard.First().WeekStart, new DateTime(1987, 9, 22));
			Assert.AreEqual(suggestedBillboard.First().MovieScreen.Count, 1);
			Assert.AreEqual(suggestedBillboard.First().MovieScreen.First().Screen, 1);
			Assert.AreEqual(suggestedBillboard.First().MovieScreen.First().Movie.Genre, "Terror");
			Assert.AreEqual(suggestedBillboard.First().MovieScreen.First().Movie.Keywords.Count, 2);
			Assert.AreEqual(suggestedBillboard.First().MovieScreen.First().Movie.Language, "English");
			Assert.AreEqual(suggestedBillboard.First().MovieScreen.First().Movie.Genre, "Terror");
			Assert.AreEqual(suggestedBillboard.First().MovieScreen.First().Movie.Overview, "...");
			Assert.AreEqual(suggestedBillboard.First().MovieScreen.First().Movie.ReleaseDate, new DateTime(1987, 9, 22));
			Assert.AreEqual(suggestedBillboard.First().MovieScreen.First().Movie.Title, "Best Movie");
			Assert.AreEqual(suggestedBillboard.First().MovieScreen.First().Movie.WebSite, "www.bestmovie.com");
		}

		[Test]
		public void GiveIntelligentBillboardWithInvalidWeeksFromNow_WhenGetIntelligentBillboard_ThenShouldReturnExpectedValues()
		{
			// Arrange
			var weeksFromNow = -1;
			var numberOfBigScreens = 1;
			var numberOfSmallScreens = 1;

			// Act
			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _sut.GetIntelligentBillboard(weeksFromNow, numberOfBigScreens, numberOfSmallScreens, true)
				.ConfigureAwait(false));

			// Assert
			Assert.That(ex.Message, Is.EqualTo("Weeks must be between 1 and 52"));
		}

		[Test]
		public void GiveIntelligentBillboardWithInvalidBigRoomsScreensNumber_WhenGetIntelligentBillboard_ThenShouldReturnExpectedValues()
		{
			// Arrange
			var weeksFromNow = 1;
			var numberOfBigScreens = 50;
			var numberOfSmallScreens = 1;

			// Act
			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _sut.GetIntelligentBillboard(weeksFromNow, numberOfBigScreens, numberOfSmallScreens, true)
				.ConfigureAwait(false));

			// Assert
			Assert.That(ex.Message, Is.EqualTo("Number of big rooms must be between 0 and 30"));
		}

		[Test]
		public void GiveIntelligentBillboardWithInvalidSmallRoomsScreensNumber_WhenGetIntelligentBillboard_ThenShouldReturnExpectedValues()
		{
			// Arrange
			var weeksFromNow = 1;
			var numberOfBigScreens = 1;
			var numberOfSmallScreens = 50;

			// Act
			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _sut.GetIntelligentBillboard(weeksFromNow, numberOfBigScreens, numberOfSmallScreens, true)
				.ConfigureAwait(false));

			// Assert
			Assert.That(ex.Message, Is.EqualTo("Number of small rooms must be between 0 and 30"));
		}

		[Test]
		public void GiveIntelligentBillboardWithInvalidTotalRoomsScreensNumber_WhenGetIntelligentBillboard_ThenShouldReturnExpectedValues()
		{
			// Arrange
			var weeksFromNow = 1;
			var numberOfBigScreens = 0;
			var numberOfSmallScreens = 0;

			// Act
			var ex = Assert.ThrowsAsync<ArgumentException>(async () => await _sut.GetIntelligentBillboard(weeksFromNow, numberOfBigScreens, numberOfSmallScreens, true)
				.ConfigureAwait(false));

			// Assert
			Assert.That(ex.Message, Is.EqualTo("Total number of rooms must be greater than 0"));
		}

		// TODO Add more test
	}
}
