using Application.Exceptions;
using Application.Parsers;
using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace MarRover.UnitTests.Application.Parsers
{
    public class PlateauParserTests
    {
        [Fact]
        public void Should_receive_measurements_on_a_string_and_create_the_plateau()
        {
            const string plateauSize = "3 5";
            var plateauParser = new PlateauParser();
            var expectedPlateau = new Plateau(3, 5);

            var parsedPlateau = plateauParser.Parse(plateauSize);

            parsedPlateau.Should().BeEquivalentTo(expectedPlateau);
        }

        [Fact]
        public void Should_not_create_a_plateau_and_return_error_message_if_format_is_incorrect()
        {
            const string plateauSize = "A 5";
            var plateauParser = new PlateauParser();

            plateauParser.Invoking(x => x.Parse(plateauSize)).Should().Throw<InvalidPlateauMeasurementsException>();
        }
    }
}