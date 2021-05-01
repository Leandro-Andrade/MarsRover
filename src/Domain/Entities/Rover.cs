using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Rover
    {
        public string FacingDirection { get; set; } // Possibly an enum
        public Position Position { get; set; }
    }
}
