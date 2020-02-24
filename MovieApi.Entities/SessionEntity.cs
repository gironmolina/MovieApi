using System;

namespace MovieApi.Entities
{
	public class SessionEntity
	{
		public int Id { get; private set; }
		public int RoomId { get; private set; }
		public int MovieId { get; private set; }
		public DateTime StartTime { get; private set; }
		public DateTime EndTime { get; private set; }
		public int? SeatsSold { get; private set; }
		public virtual MovieEntity Movie { get; private set; }
		public virtual RoomEntity Room { get; private set; }
    }
}
