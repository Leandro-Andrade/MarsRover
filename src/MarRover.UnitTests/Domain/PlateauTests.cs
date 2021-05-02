using Domain.Entities;
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
    }
}