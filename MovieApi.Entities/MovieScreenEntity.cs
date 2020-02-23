namespace MovieApi.Entities
{
	public class MovieScreenEntity
	{
		public int Screen { get; set; }

		public RecommendationMovieEntity Movie { get; set; }
	}
}
