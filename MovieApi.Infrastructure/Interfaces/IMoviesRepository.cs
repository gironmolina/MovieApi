using System.Collections.Generic;
using System.Threading.Tasks;
using MovieApi.Entities;

namespace MovieApi.Infrastructure.Interfaces
{
	public interface IMoviesRepository
	{
		Task<List<MovieInfoEntity>> GetMoviesInfoFromDb();

		Task<List<MovieInfoEntity>> GetMoviesInfoFromApi();
	}
}
