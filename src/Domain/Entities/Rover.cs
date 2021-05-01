using System;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Rover
    {
        public Guid Id { get; set; }
        public FacingDirection FacingDirection { get; set; }
        public Position Position { get; set; }
    }
}
