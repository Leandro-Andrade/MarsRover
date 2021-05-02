using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Rover
    {
        public FacingDirection FacingDirection { get; set; }
        public Position Position { get; set; }
        public Plateau Plateau { get; set; }

        public Rover(FacingDirection facingDirection, Position position, Plateau plateau)
        {
            FacingDirection = facingDirection;
            Position = position;
            Plateau = plateau;
        }
    }
}
