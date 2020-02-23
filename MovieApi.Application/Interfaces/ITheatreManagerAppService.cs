namespace MovieApi.Application.Interfaces
{
	public interface ITheatreManagerAppService
	{
		void GetUpcomingMovies(int weeksFromNow, string ageRate, string genre);
	}
}
