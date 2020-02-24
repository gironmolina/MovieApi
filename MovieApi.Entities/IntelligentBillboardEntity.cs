using System;
using System.Collections.Generic;

namespace MovieApi.Entities
{
	public class IntelligentBillboardEntity
	{
		public DateTime WeekStart { get; set; }
		public List<MovieScreenEntity> BigScreensMovies { get; set; }
		public List<MovieScreenEntity> SmallScreensMovies { get; set; }
	}
}
