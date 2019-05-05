using System;
using System.Collections.Generic;
using System.Text;

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
