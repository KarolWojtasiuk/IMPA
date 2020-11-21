using System;

namespace IMPA
{
    public class ItemDoesNotExistException : Exception
    {
        public ItemDoesNotExistException(Guid id, Type type) : base($"{type.Name}({id}) does not exist in database.") { }
    }

    public class LoginFailedException : Exception
    {
        public LoginFailedException(string message) : base($"User(N/A): {message}") { }
        public LoginFailedException(Guid id, string message) : base($"User({id}): {message}") { }
    }
}
