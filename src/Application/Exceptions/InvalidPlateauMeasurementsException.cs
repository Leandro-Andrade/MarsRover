using System;

namespace Application.Exceptions
{
    public class InvalidPlateauMeasurementsException : Exception
    {
        public InvalidPlateauMeasurementsException(string measurement)
            : base($"Invalid Plateau measurement: {measurement}. Please use this format: X Y (e.g. 4 4)")
        {
        }
    }
}