using System;

namespace Cosmetics.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message)
            : base(message)
        {

        }
    }
}
