using System;

namespace MovieManagement.Services.Exceptions
{
    public class EntityInvalidException : Exception
    {
        public EntityInvalidException(string message)
            : base(message)
        {
        }
    }
}