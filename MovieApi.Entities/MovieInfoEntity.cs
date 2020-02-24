using System;
using System.Collections.Generic;
using MovieApi.Entities.Enums;

namespace MovieApi.Entities
{
	public class MovieInfoEntity : MovieFileEntity
	{
		public RoomSizeType RoomSize { get; }

		public int TotalSeatsSold { get; }

		public MovieInfoEntity(string title, string overview, string genre, string language, DateTime releaseDate, string webSite, List<string> keywords, RoomSizeType roomSize, int totalSeatsSold) :
			base(title, overview, genre, language, releaseDate, webSite, keywords)
		{
			RoomSize = roomSize;
			TotalSeatsSold = totalSeatsSold;
		}
		public MovieInfoEntity(MovieFileEntity movie, RoomSizeType roomSize, int totalSeatsSold) :
			base(movie)
		{
			RoomSize = roomSize;
			TotalSeatsSold = totalSeatsSold;
		}
    }
}
