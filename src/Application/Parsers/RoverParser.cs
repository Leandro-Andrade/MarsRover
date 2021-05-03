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
            string[] positions = roverStartPosition.Split(' ');

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

            var facingDirection = new FacingDirectionParser().Parse(positions[2]);
            var position = new Position(x, y);

            return new Rover(facingDirection, position);
        }
    }
}