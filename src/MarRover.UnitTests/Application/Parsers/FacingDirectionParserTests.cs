using Application.Exceptions;
using Application.Parsers;
using Domain.Enums;
using FluentAssertions;
using Xunit;

namespace MarRover.UnitTests.Application.Parsers
{
    public class FacingDirectionParserTests
    {
        [Fact]
        public void Should_receive_in_a_string_and_return_a_FacingDirection()
        {
            const string facingDirectionInput = "W";
            const FacingDirection expectedFacingDirection = FacingDirection.W;

            var parsedEnum = new FacingDirectionParser().Parse(facingDirectionInput);

            parsedEnum.Should().Be(expectedFacingDirection);
        }

        [Fact]
        public void Should_throw_exception_if_invalid_facing_direction()
        {
            var parser = new FacingDirectionParser();

            parser.Invoking(x => x.Parse("bla")).Should().Throw<InvalidFacingDirectionException>();
        }
    }
}