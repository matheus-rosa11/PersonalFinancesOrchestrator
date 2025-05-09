using Shared.Utils.Extensions;
using Shared.Utils.Helpers;

namespace Shared.DTO.Users
{
    public class UserCreateDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public DateTime? CreatedDate { get; private set; }

        public (bool, string) Validate()
        {
            if (Name.IsNullOrWhiteSpace())
                return (false, MessageHelper.FieldCannotBeNullOrWhiteSpace(nameof(Name)));

            if (!Email.IsValidEmail())
                return (false, MessageHelper.InvalidEmail());

            if (Password.IsNullOrWhiteSpace())
                return (false, MessageHelper.FieldCannotBeNullOrWhiteSpace(nameof(Password)));

            return (true, string.Empty);
        }

        public void SetCreatedDate(DateTime createdDate) => CreatedDate = createdDate;
    }
}
