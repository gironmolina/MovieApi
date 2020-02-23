namespace MovieApi.Application.Dtos
{
	public class RecommendationTvShowDto : RecommendationDto
	{
		public int NumberOfSeasons { get; set; }

		public int NumberOfEpisodes { get; set; }

		public bool IsConcluded { get; set; }
	}
}
