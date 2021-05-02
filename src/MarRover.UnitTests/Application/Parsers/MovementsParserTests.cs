using System.Collections.Generic;
using System.Linq;
using Application.Exceptions;
using Application.Parsers;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace MarRover.UnitTests.Application.Parsers
{
    public class MovementsParserTests
    {
        [Fact]
        public void Should_receive_movements_in_a_string_and_return_a_list_with_individual_movements_preserving_the_sequence()
        {
            const string movements = "RMLM";
            var moveParser = new MovementsParser();
            var expectedMovements = new List<MovementType>()
            {
                MovementType.Right,
                MovementType.Forward,
                MovementType.Left,
                MovementType.Forward
            };

            var parsed = moveParser.Parse(movements);

            parsed.SequenceEqual(expectedMovements).Should().BeTrue();
        }

        [Fact]
        public void Should_return_an_error_if_there_is_an_invalid_movement()
        {
            const string movementsArgs = "RMLMA";
            var moveParser = new MovementsParser();

            moveParser.Invoking(x => x.Parse(movementsArgs)).Should().Throw<InvalidMovementException>();
        }
    }
}
