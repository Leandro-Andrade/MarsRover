using Domain.Exceptions;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.ValueObjects
{
    public class PositionTests
    {
        [Fact]
        public void ToString_should_return_a_formatted_cartesian_coordinate()
        {
            var position = new Position(3, 5);

            string formattedPosition = position.ToString();

            formattedPosition.Should().Be("(3, 5)");
        }

        [Fact]
        public void Equality_should_be_a_deep_comparison()
        {
            var position = new Position(3, 5);
            var position2 = new Position(3, 5);

            position.Equals(position2).Should().BeTrue();
            (position == position2).Should().BeTrue();

            position2 = new Position(5, 3);

            position.Equals(position2).Should().BeFalse();
            (position == position2).Should().BeFalse();
        }

        [Fact]
        public void GetHashCode_should_consider_hash_of_all_properties()
        {
            var position = new Position(3, 5);
            var position2 = new Position(3, 5);

            int hash1 = position.GetHashCode();
            int hash2 = position2.GetHashCode();

            hash1.Should().Be(hash2);
        }

        [Fact]
        public void Should_throw_InvalidNegativePositionException_if_negative_coordinate()
        {
            FluentActions.Invoking(() => new Position(-1, -3))
                .Should().Throw<InvalidNegativePositionException>();
        }
    }
}
