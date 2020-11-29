using System;

namespace IMPA
{
    public class ItemDoesNotExistException : IMPAException
    {
        public ItemDoesNotExistException(Guid id, Type type) : base($"{type.Name}({id}) does not exist in database.") { }
    }

    public class ModelVerificationException : IMPAException
    {
        public ModelVerificationException(Guid id, Type type, string message) : base($"{type.Name}({id}): {message}") { }
    }

    public class InsufficientPermissionException : IMPAException
    {
        public InsufficientPermissionException(Guid id, string action) : base($"User({id}): You do not have sufficient permission to perform action `{action}`.") { }
    }

    public class IMPAException : Exception
    {
        public IMPAException(string message) : base(message) { }
    }
}
