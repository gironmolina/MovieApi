using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Entities;

namespace MovieApi.Domain.Interfaces
{
	public interface ITheatreManagerService
	{
		Task<IEnumerable<RecommendationMovieEntity>> GetUpcomingMovies(int weeksFromNow, string ageRate, string genre);

		Task<IEnumerable<BillboardEntity>> GetSuggestedBillboard(int weeksFromNow, int numberOfScreens, bool basedOnCityMovies);
	}
}
