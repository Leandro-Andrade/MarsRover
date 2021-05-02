using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Plateau
    {
        public int Width { get; }
        public int Height { get; }
        public int StartX { get; }
        public int StartY { get; }
        public int EndX { get; }
        public int EndY { get; }

        public Plateau(int width, int height)
        {
            StartX = 0;
            StartY = 0;
            Width = width;
            Height = height;
            EndX = width + StartX;
            EndY = height + StartY;
        }

        public bool IsWithinBounds(Position targetPosition)
        {
            return (targetPosition.X >= StartX && targetPosition.X <= EndX) &&
                   (targetPosition.Y >= StartY && targetPosition.Y <= EndY);
        }
    }
}