namespace MovieApi.CrossCutting.Interfaces
{
	public interface IAppConfigSettings
	{
		string DiscoverMovieUrl { get; }
		string GenreListUrl { get; }
		string ApiKey { get; }
		string SortBy { get; }
		string BeezyCinemaDb { get; }
	}
}
