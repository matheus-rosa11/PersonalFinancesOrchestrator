using Shared.Utils.Extensions;

namespace Shared.DTO.Users
{
    public class UserCreateDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; private set; }

        public bool Validate()
        {
            if (Name == null)
                return false;

            if (!Email.IsValidEmail())
                return false;

            if (Password == null)
                return false;

            return true;
        }

        public void SetCreatedDate(DateTime createdDate) => CreatedDate = createdDate;
    }
}
