using System;

namespace MovieApi.CrossCutting.Exceptions
{
	public class ManagerTheatreException : Exception
	{
		public ManagerTheatreException()
		{
		}

		public ManagerTheatreException(string message)
			: base(message)
		{
		}

		public ManagerTheatreException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
