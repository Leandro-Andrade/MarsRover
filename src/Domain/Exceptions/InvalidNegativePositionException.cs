using System;

namespace Domain.Exceptions
{
    public class InvalidPlateauSizeException : Exception
    {
        public InvalidPlateauSizeException(int width, int length) :
            base($"Invalid Plateau size: W={width}, L={length}. The Plateau measurements must be positive and the area be at least 4 (width * length).")
        {
        }
    }
}
