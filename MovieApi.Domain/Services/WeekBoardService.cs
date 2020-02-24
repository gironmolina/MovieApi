using System;
using System.Collections.Generic;
using System.Linq;
using MovieApi.Domain.Interfaces;
using MovieApi.Entities;
using MovieApi.Entities.Enums;

namespace MovieApi.Domain.Services
{
	public class WeekBoardService : IWeekBoardService
	{
		private readonly IWeekDatesService _weekDatesService;

		public WeekBoardService(IWeekDatesService weekDatesService)
		{
			_weekDatesService = weekDatesService;
		}

		public WeekBoardEntity GetWeekBoardEntity(
			DateTime weekDate, 
			List<MovieInfoEntity> bigMoviesList, 
			int numberOfBigScreens, 
			List<MovieInfoEntity> smallMoviesList,
			int numberOfSmallScreens)
		{
			var bigScreenBoard = GetBigScreenBoard(bigMoviesList, numberOfBigScreens, weekDate);
			var smallScreenBoard = GetSmallScreenBoard(smallMoviesList, numberOfSmallScreens, weekDate);
			var weekBoard = new WeekBoardEntity(weekDate, bigScreenBoard, smallScreenBoard);
			return weekBoard;
		}

		public IEnumerable<WeekBoardEntity> GetWeekBoardsFromMoviesInfo(
			List<MovieInfoEntity> moviesInfo, 
			int weeksFromNow, 
			int numberOfBigScreens,
			int numberOfSmallScreens)
		{
			if (moviesInfo == null || moviesInfo.Count == 0)
			{
				yield break;
			}

			var bigMoviesList = new List<MovieInfoEntity>(moviesInfo.Where(m => m.RoomSize == RoomSizeType.Big).OrderByDescending(m => m.TotalSeatsSold));
			var smallMoviesList = new List<MovieInfoEntity>(moviesInfo.Where(m => m.RoomSize == RoomSizeType.Small).OrderByDescending(m => m.TotalSeatsSold));

			foreach (var weekDate in _weekDatesService.GetWeekDates(weeksFromNow))
			{
				var weekBoard = GetWeekBoardEntity(weekDate, bigMoviesList, numberOfBigScreens, smallMoviesList, numberOfSmallScreens);
				yield return weekBoard;
			}
		}

		private List<ScreenBoardEntity> GetBigScreenBoard(List<MovieInfoEntity> bigMoviesList, int numberOfBigScreens, DateTime weekStart)
		{
			return GetScreenBoardFromList(bigMoviesList, numberOfBigScreens, weekStart).ToList();
		}

		private List<ScreenBoardEntity> GetSmallScreenBoard(List<MovieInfoEntity> smallMoviesList, int numberOfSmallScreens, DateTime weekStart)
		{
			return GetScreenBoardFromList(smallMoviesList, numberOfSmallScreens, weekStart).ToList();
		}

		private IEnumerable<ScreenBoardEntity> GetScreenBoardFromList(List<MovieInfoEntity> moviesList, int numberRoomsScreens, DateTime weekStart)
		{
			for (var screenIndex = 1; screenIndex <= numberRoomsScreens; screenIndex++)
			{
				var movie = GetNextMovieFromList(moviesList, weekStart);
				if (movie != null)
				{
					moviesList.Remove(movie);
				}

				yield return new ScreenBoardEntity(screenIndex, movie);
			}
		}

		private MovieInfoEntity GetNextMovieFromList(List<MovieInfoEntity> moviesList, DateTime weekStart)
		{
			return moviesList.FirstOrDefault(m => m.ReleaseDate <= weekStart);
		}
	}
}
