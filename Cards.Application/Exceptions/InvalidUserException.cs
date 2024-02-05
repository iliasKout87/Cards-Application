namespace Cards.Application.Exceptions
{
	public class InvalidUserException : Exception
	{
		public InvalidUserException() : base("User doesn't exist")
		{

		}
	}
}
