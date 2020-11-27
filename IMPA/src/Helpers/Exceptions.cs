using System;

namespace IMPA
{
    public class ItemDoesNotExistException : Exception
    {
        public ItemDoesNotExistException(Guid id, Type type) : base($"{type.Name}({id}) does not exist in database.") { }
    }

    public class ModelVerificationException : Exception
    {
        public ModelVerificationException(Guid id, Type type, string message) : base($"{type.Name}({id}): {message}") { }
    }

    public class InsufficientPermissionException : Exception
    {
        public InsufficientPermissionException(Guid id, string action) : base($"User({id}): You do not have sufficient permission to perform action `{action}`.") { }
    }
}
