using System;

namespace Domain.Exceptions
{
    public class InvalidNegativePositionException : Exception
    {
        public InvalidNegativePositionException(string position) 
            : base($"The position {position} is not valid. A rover cannot be at a negative position.")
        {
        }
    }
}
