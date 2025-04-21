namespace Shared.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }

        public void ChangePassword(string newPassword) => Password = newPassword;
    }
}
