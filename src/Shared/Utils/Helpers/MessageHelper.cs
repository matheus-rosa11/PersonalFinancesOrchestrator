namespace Shared.Utils.Helpers
{
    public static class MessageHelper<TKey>
    {
        public static string EntityNotFound(TKey id) => $"Entity with id {id} not found.";
        public static string EntityNotFoundByEmail(string email) => $"Entity with email {email} not found.";
    }
}
