using System;

namespace Application.Exceptions
{
    public class InvalidRoverException : Exception
    {
        public InvalidRoverException(string rover)
            : base($"Invalid rover declaration: {rover}. Please use this format: [X] [Y] [FacingDirection] (e.g. 1 1 N)")
        {
        }
    }
}