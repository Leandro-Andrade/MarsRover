using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace MarRover.UnitTests.Domain
{
    public class PlateauTests
    {
        [Fact]
        public void IsWithinBounds_should_return_true_if_target_position_is_within_the_plateau()
        {
            var plateau = new Plateau(5, 5);

            bool isWithinBounds = plateau.IsWithinBounds(new Position(0, 5));

            isWithinBounds.Should().BeTrue();
        }

        [Fact]
        public void IsWithinBounds_should_return_false_if_target_position_is_outside_the_plateau()
        {
            var plateau = new Plateau(5, 5);

            bool isWithinBounds = plateau.IsWithinBounds(new Position(6, 5));

            isWithinBounds.Should().BeFalse();
        }

        [Fact]
        public void Should_throw_exception_if_any_measurement_is_negative()
        {
            FluentActions.Invoking(() => new Plateau(-5, -5)).Should().Throw<InvalidPlateauSizeException>();
        }

        [Fact]
        public void Should_throw_exception_if_area_is_less_than_four()
        {
            FluentActions.Invoking(() => new Plateau(0, 2)).Should().Throw<InvalidPlateauSizeException>();
        }
    }
}