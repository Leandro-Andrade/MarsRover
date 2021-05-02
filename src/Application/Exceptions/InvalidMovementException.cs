using System;

namespace Application.Exceptions
{
    public class InvalidMovementException : Exception
    {
        public InvalidMovementException(string movement)
            : base($"Invalid movement sequence: {movement}. Use only L, R or M  (e.g. LRMLM)")
        {
        }
    }
}