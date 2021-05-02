using System.Collections.Generic;
using Application.Exceptions;
using Domain.Enums;

namespace Application.Parsers
{
    public class MovementsParser
    {
        public IReadOnlyCollection<MovementType> Parse(string movements)
        {
            var directions = new List<MovementType>();

            foreach (char movement in movements)
            {
                string movementString = movement.ToString().ToUpper();

                if (movementString != "L" && movementString != "R" && movementString != "M")
                    throw new InvalidMovementException(movementString);

                switch (movement.ToString())
                {
                    case "M":
                        directions.Add(MovementType.Forward);
                        break;
                    case "R":
                        directions.Add(MovementType.Right);
                        break;
                    case "L":
                        directions.Add(MovementType.Left);
                        break;
                }
            }

            return directions;
        }
    }
}