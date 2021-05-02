using System;
using Application.Parsers;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace MarRover.UnitTests.Application.Parsers
{
    public class RoverParserTests
    {
        [Fact]
        public void Should_receive_positions_in_a_string_and_return_a_Rover_object()
        {
            const string roverInput = "1 1 W";
            var roverParser = new RoverParser();
            var expectedRover = new Rover(FacingDirection.W, new Position(1, 1));

            var parsedRover = roverParser.Parse(roverInput);

            parsedRover.Should().BeEquivalentTo(expectedRover);
        }

        [Theory]
        [InlineData("-1 2.5 N")]
        [InlineData("1 1 Bla")]
        [InlineData("Bla")]
        [InlineData("1 1 1")]
        public void Should_not_create_a_rover_and_return_error_message_if_format_is_incorrect(string roverInput)
        {
            var roverParser = new RoverParser();

            roverParser.Invoking(x => x.Parse(roverInput)).Should().Throw<Exception>();
        }
    }
}