using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Rover
    {
        public FacingDirection FacingDirection { get; set; }
        public Position Position { get; set; }

        public Rover(FacingDirection facingDirection, Position position)
        {
            FacingDirection = facingDirection;
            Position = position;
        }
    }
}
