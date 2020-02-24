using System;
using System.Collections.Generic;

namespace MovieApi.Entities
{
	public class WeekBoardEntity
	{
		public WeekBoardEntity(
			DateTime weekDate, 
			List<ScreenBoardEntity> bigScreenBoard, 
			List<ScreenBoardEntity> smallScreenBoard)
		{
			WeekStart = weekDate;
			BigScreenBoard = bigScreenBoard;
			SmallScreenBoard = smallScreenBoard;
		}

		public DateTime WeekStart { get; }

		public List<ScreenBoardEntity> BigScreenBoard { get; }

		public List<ScreenBoardEntity> SmallScreenBoard { get; }
	}
}
