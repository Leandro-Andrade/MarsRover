using System;
using Application.Exceptions;
using Domain.Entities;

namespace Application.Parsers
{
    public class PlateauParser
    {
        public Plateau Parse(string plateauArea)
        {
            string[] measurements = plateauArea.Split(' ');
            int width, length;

            try
            {
                width = Convert.ToInt32(measurements[0]);
                length = Convert.ToInt32(measurements[1]);
            }
            catch
            {
                throw new InvalidPlateauMeasurementsException(plateauArea);
            }

            return new Plateau(width, length);
        }
    }
}