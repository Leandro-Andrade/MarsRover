using System;

namespace Application.Exceptions
{
    public class InvalidFacingDirectionException : Exception
    {
        public InvalidFacingDirectionException(string facingDirection)
            : base($"Invalid facing direction: {facingDirection}. Use N, S, E or W")
        {
        }
    }
}