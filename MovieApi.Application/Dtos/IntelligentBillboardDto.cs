using System;
using System.Collections.Generic;

namespace MovieApi.Application.Dtos
{
	public class IntelligentBillboardDto
	{
		public DateTime WeekStart { get; set; }
		public List<MovieScreenDto> BigScreensMovies { get; set; }
		public List<MovieScreenDto> SmallScreensMovies { get; set; }
	}
}
