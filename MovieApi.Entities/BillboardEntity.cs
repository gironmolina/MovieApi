using System;
using System.Collections.Generic;

namespace MovieApi.Entities
{
	public class BillboardEntity
	{
		public DateTime WeekStart { get; set; }
		public List<MovieScreenEntity> MovieScreen { get; set; }
	}
}
