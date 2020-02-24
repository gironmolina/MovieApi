namespace MovieApi.Entities
{
	public class ScreenBoardEntity
	{
		public int Screen { get; private set; }

		public MovieFileEntity Movie { get; private set; }

		public ScreenBoardEntity(int screen, MovieFileEntity movie)
		{
			Screen = screen;
			Movie = movie;
		}
    }
}
