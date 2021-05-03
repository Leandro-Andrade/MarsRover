using Domain.Exceptions;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Plateau
    {
        private const int MinimumPlateauArea = 4;
        public int Width { get; }
        public int Length { get; }
        public int StartX { get; }
        public int StartY { get; }
        public int EndX => Width + StartX;
        public int EndY => Length + StartY;

        public Plateau(int width, int length)
        {
            if (width <= 0 || length <= 0 || width * length < MinimumPlateauArea)
            {
                throw new InvalidPlateauSizeException(width, length);
            }

            StartX = 0;
            StartY = 0;
            Width = width;
            Length = length;
        }

        public bool IsWithinBounds(Position targetPosition)
        {
            return (targetPosition.X >= StartX && targetPosition.X <= EndX) &&
                   (targetPosition.Y >= StartY && targetPosition.Y <= EndY);
        }
    }
}