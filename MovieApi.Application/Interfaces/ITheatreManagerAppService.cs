using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Application.Dtos;

namespace MovieApi.Application.Interfaces
{
	public interface ITheatreManagerAppService
	{
		Task<IEnumerable<RecommendationMovieDto>> GetUpcomingMovies(int weeksFromNow, string ageRate, string genre);
		Task<IEnumerable<BillboardDto>> GetSuggestedBillboard(int weeksFromNow, int numberOfScreens, bool basedOnCityMovies);
	}
}
