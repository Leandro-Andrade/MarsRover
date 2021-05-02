using System.Collections.Generic;
using Domain.Common;

namespace Domain.ValueObjects
{
    public class Position : ValueObject
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return X;
            yield return Y;
        }
    }
}
