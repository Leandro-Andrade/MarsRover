using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Rovers.Commands;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace MarRover.UnitTests.Application.Rovers
{
    public class MoveRoverCommandTests
    {
        [Theory]
        [InlineData(0, 1, MovementType.Forward)]
        [InlineData(0, 2, MovementType.Forward, MovementType.Forward)]
        [InlineData(1, 1, MovementType.Forward, MovementType.Right, MovementType.Forward)]
        [InlineData(1, 2, MovementType.Forward, MovementType.Right, MovementType.Forward, MovementType.Left, MovementType.Forward)]
        public async Task Should_move_rover_to_the_expected_position(int expectedX, int expectedY, params MovementType[] movements)
        {
            var rover = new Rover
            {
                FacingDirection = FacingDirection.North,
                Position = new Position(0, 0)
            };

            var expectedPosition = new Position(expectedX, expectedY);

            var command = new MoveRoverCommand
            {
                Rover = rover,
                Movements = new List<MovementType>(movements)
            };

            var commandHandler = new MoveRoverCommandHandler();

            await commandHandler.Handle(command, CancellationToken.None);

            rover.Position.Should().Be(expectedPosition);
        }
    }
}
