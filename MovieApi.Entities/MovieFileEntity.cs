using System;
using System.Collections.Generic;

namespace MovieApi.Entities
{
	public class MovieFileEntity
	{
		public string Title { get; }
		public string Overview { get; }
		public string Genre { get; }
		public string Language { get; }
		public DateTime ReleaseDate { get; }
		public string WebSite { get; }
		public List<string> Keywords { get; }

		public MovieFileEntity(string title, string overview, string genre, string language, DateTime releaseDate, string webSite, List<string> keywords)
		{
			Title = title;
			Overview = overview;
			Genre = genre;
			Language = language;
			ReleaseDate = releaseDate;
			WebSite = webSite;
			Keywords = keywords;
		}

		public MovieFileEntity(MovieFileEntity movie)
		{
			Title = movie.Title;
			Overview = movie.Overview;
			Genre = movie.Genre;
			Language = movie.Language;
			ReleaseDate = movie.ReleaseDate;
			WebSite = movie.WebSite;
			Keywords = movie.Keywords;
		}
	}
}
