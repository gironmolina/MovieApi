using System;
using System.Collections.Generic;

namespace MovieApi.Domain.Interfaces
{
	public interface IWeekDatesService
	{
		IEnumerable<DateTime> GetWeekDates(int weeksFromNow);
	}
}
