using System;
using System.Collections.Generic;
using MovieApi.Entities;

namespace MovieApi.Domain.Interfaces
{
	public interface IWeekBoardService
	{
		WeekBoardEntity GetWeekBoardEntity(
			DateTime weekDate, 
			List<MovieInfoEntity> bigMoviesList, 
			int numberOfBigScreens, 
			List<MovieInfoEntity> smallMoviesList, 
			int numberOfSmallScreens);

		IEnumerable<WeekBoardEntity> GetWeekBoardsFromMoviesInfo(
			List<MovieInfoEntity> moviesInfo,
			int weeksFromNow,
			int numberOfBigScreens,
			int numberOfSmallScreens);
	}
}
