using Shared.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exceptions.Users
{
    public class UserAlreadyExistsException(string email) : ArgumentException
    {
        public override string Message => MessageHelper.UserEmailAlreadyExists(email);
    }
}
