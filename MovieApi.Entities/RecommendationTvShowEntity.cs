namespace MovieApi.Entities
{
	public class RecommendationTvShowEntity : RecommendationEntity
	{
		public int NumberOfSeasons { get; set; }

		public int NumberOfEpisodes { get; set; }

		public bool IsConcluded { get; set; }
	}
}
