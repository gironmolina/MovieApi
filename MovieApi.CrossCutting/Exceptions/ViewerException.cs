using System;

namespace MovieApi.CrossCutting.Exceptions
{
	public class ViewerException : Exception
	{
		public ViewerException()
		{
		}

		public ViewerException(string message)
			: base(message)
		{
		}

		public ViewerException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
