using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Application.Dtos;

namespace MovieApi.Application.Interfaces
{
	public interface IViewerAppService
	{
		Task<IEnumerable<RecommendationMovieDto>> GetUpcomingMovies(List<string> keywords, List<string> genres, int weeksFromNow);

		Task<IEnumerable<RecommendationMovieDto>> GetAllTimeMovies(List<string> keywords, List<string> genres);

		Task<IEnumerable<RecommendationTvShowDto>> GetAllTimeTvShows(List<string> keywords, List<string> genres);

		Task<IEnumerable<RecommendationDocumentaryDto>> GetAllTimeDocumentaries(List<string> topics);
	}
}
