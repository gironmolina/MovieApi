using System;
using System.Collections.Generic;

namespace MovieApi.Entities
{
	public class MovieEntity
	{
		public MovieEntity()
		{
			Session = new HashSet<SessionEntity>();
		}

		public MovieEntity(string originalTitle, DateTime releaseDate, string originalLanguage, bool adult)
		{
			OriginalTitle = originalTitle;
			ReleaseDate = releaseDate;
			OriginalLanguage = originalLanguage;
			Adult = adult;

			Session = new HashSet<SessionEntity>();
		}

		public int Id { get; private set; }
		public string OriginalTitle { get; }
		public DateTime ReleaseDate { get; }
		public string OriginalLanguage { get; }
		public bool Adult { get; }
		public virtual ICollection<SessionEntity> Session { get; }
    }
}
