namespace Shared.Utils.Helpers
{
    public static class MessageHelper
    {
        public static string EntityNotFound<TKey>(TKey id) => $"Entity with id {id} not found.";
        public static string EntityNotFoundByEmail(string email) => $"Entity with email {email} not found.";
        public static string UnknownErrorOnEntityCreation() => $"An unknown error ocurred while trying to create a new entity.";
    }
}