using System;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Exceptions
{
    public class OffGridMovementException : Exception
    {
        public OffGridMovementException(Position position, FacingDirection facingDirection) 
            : base($"The final destination was not reached because the rover would fall off grid. " +
                   $"The rover stopped at {position}, Facing={facingDirection} and is waiting for rescue!")
        {
        }
    }
}
