using System;
using System.Collections.Generic;
using MovieApi.Domain.Interfaces;

namespace MovieApi.Domain.Services
{
	public class WeekDatesService : IWeekDatesService
	{
		private const DayOfWeek WEEK_START = DayOfWeek.Monday;

		public IEnumerable<DateTime> GetWeekDates(int weeksFromNow)
		{
			for (int weekIndex = 0; weekIndex < weeksFromNow; weekIndex++)
			{
				yield return StartOfWeek(DateTime.UtcNow.AddDays(7 * (weekIndex + 1)), WEEK_START);
			}
		}

		private static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
		{
			var diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
			return dt.AddDays(-1 * diff).Date;
		}
	}
}
