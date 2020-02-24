using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Entities
{
	public class RoomEntity
	{
		public RoomEntity()
		{
			Session = new HashSet<SessionEntity>();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public string Size { get; private set; }
		public int Seats { get; private set; }
		public int CinemaId { get; private set; }
		public virtual CinemaEntity Cinema { get; private set; }
		public virtual ICollection<SessionEntity> Session { get; }
    }
}
