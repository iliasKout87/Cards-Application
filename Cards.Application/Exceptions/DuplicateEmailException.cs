namespace Cards.Application.Exceptions
{
	public class DuplicateEmailException : Exception
	{
		public DuplicateEmailException(string email) : base($"User email {email} already exists")
		{

		}
	}
}
