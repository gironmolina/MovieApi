using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Entities;

namespace MovieApi.Domain.Interfaces
{
	public interface IViewerService
	{
		Task<IEnumerable<RecommendationMovieEntity>> GetUpcomingMovies(List<string> keywords, List<string> genres, int weeksFromNow);

		Task<IEnumerable<RecommendationMovieEntity>> GetAllTimeMovies(List<string> keywords, List<string> genres);

		Task<IEnumerable<RecommendationTvShowEntity>> GetAllTimeTvShows(List<string> keywords, List<string> genres);

		Task<IEnumerable<RecommendationDocumentaryEntity>> GetAllTimeDocumentaries(List<string> topics);
	}
}
