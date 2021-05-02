using System;
using Application.Exceptions;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Parsers
{
    public class RoverParser
    {
        public Rover Parse(string roverStartPosition)
        {
            var positions = roverStartPosition.Split(' ');

            int x, y;

            try
            {
                x = Convert.ToInt32(positions[0]);
                y = Convert.ToInt32(positions[1]);
            }
            catch (Exception e)
            {
                throw new InvalidRoverException(roverStartPosition);
            }

            if (positions[2] != "N" && positions[2] != "S" && positions[2] != "E" && positions[2] != "W")
            {
                throw new InvalidFacingDirectionException(positions[2]);
            }

            var facingDirection = new FacingDirectionParser().Parse(positions[2]);
            var position = new Position(x, y);

            return new Rover(facingDirection, position);
        }
    }
}