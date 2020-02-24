using System.Collections.Generic;

namespace MovieApi.Entities
{
	public class CityEntity
	{
		public CityEntity()
		{
			Cinema = new HashSet<CinemaEntity>();
		}

		public int Id { get; private set; }
		public string Name { get; private set; }
		public int Population { get; private set; }

		public virtual ICollection<CinemaEntity> Cinema { get; }
    }
}
