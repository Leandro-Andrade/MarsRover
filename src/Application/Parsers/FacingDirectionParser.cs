using System;
using Application.Exceptions;
using Domain.Enums;

namespace Application.Parsers
{
    public class FacingDirectionParser
    {
        public FacingDirection Parse(string facingDirectionInput)
        {
            if (facingDirectionInput != "N" && facingDirectionInput != "S" && facingDirectionInput != "E" && facingDirectionInput != "W")
            {
                throw new InvalidFacingDirectionException(facingDirectionInput);
            }

            return Enum.Parse<FacingDirection>(facingDirectionInput);

        }
    }
}