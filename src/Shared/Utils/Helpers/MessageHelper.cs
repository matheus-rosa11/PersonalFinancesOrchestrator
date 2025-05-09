using Shared.Utils.Extensions;

namespace Shared.Utils.Helpers
{
    public static class MessageHelper
    {
        public static string EntityNotFound<TKey>(TKey id) => $"Entity with id {id} not found.";
        public static string EntityNotFoundByEmail(string email) => $"Entity with email {email} not found.";
        public static string UserEmailAlreadyExists(string email) => $"User with e-mail {email} already exists.";
        public static string UnknownErrorOnEntityCreation() => $"An unknown error ocurred while trying to create a new entity.";
        public static string FieldCannotBeNullOrEmpty(string fieldName) => $"{fieldName.Capitalize()} cannot be null or empty.";
        public static string FieldCannotBeNullOrWhiteSpace(string fieldName) => $"{fieldName.Capitalize()} cannot be null or white spaces.";
        public static string InvalidEmail() => "Invalid e-mail.";
    }
}