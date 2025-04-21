using Shared.Utils.Helpers;

namespace Shared.Exceptions.Users
{
    public class NotFoundByEmailException(string email) : Exception
    {
        public override string Message => MessageHelper.EntityNotFoundByEmail(email);
    }
}
