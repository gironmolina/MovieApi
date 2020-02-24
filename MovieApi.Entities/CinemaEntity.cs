using System;
using System.Collections.Generic;

namespace MovieApi.Entities
{
	public class CinemaEntity
	{
		public CinemaEntity()
		{
			Room = new HashSet<RoomEntity>();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public DateTime OpenSince { get; private set; }
		public int CityId { get; private set; }
		public virtual CityEntity City { get; private set; }
		public virtual ICollection<RoomEntity> Room { get; }
	}
}
