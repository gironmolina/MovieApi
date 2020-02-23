using System;
using System.Collections.Generic;

namespace MovieApi.Application.Dtos
{
	public class BillboardDto
	{
		public DateTime WeekStart { get; set; }
		public List<MovieScreenDto> MovieScreen { get; set; }
	}
}
