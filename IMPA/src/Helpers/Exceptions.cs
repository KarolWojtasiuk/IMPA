using System;

namespace IMPA
{
    public class ItemDoesNotExistException : Exception
    {
        public ItemDoesNotExistException(Guid id, Type type) : base($"{type.Name}({id}) does not exist in database.") { }
    }
}
