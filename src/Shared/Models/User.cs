namespace Shared.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; private set; }
        public DateTime? CreatedDate { get; set; }

        public void ChangePassword(string newPassword) => Password = newPassword;
    }
}
