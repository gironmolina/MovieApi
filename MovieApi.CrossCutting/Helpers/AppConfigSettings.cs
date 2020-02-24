using System.Configuration;
using MovieApi.CrossCutting.Interfaces;

namespace MovieApi.CrossCutting.Helpers
{
	public class AppConfigSettings : IAppConfigSettings
	{
		public string DiscoverMovieUrl { get; }

		public string GenreListUrl { get; }

		public string ApiKey { get; }

		public string SortBy { get; }

		public AppConfigSettings()
		{
			this.DiscoverMovieUrl = ConfigurationManager.AppSettings["DiscoverMovieUrl"];
			this.GenreListUrl = ConfigurationManager.AppSettings["GenreListUrl"];
			this.ApiKey = ConfigurationManager.AppSettings["ApiKey"];
			this.SortBy = ConfigurationManager.AppSettings["SortBy"];
		}
	}
}
