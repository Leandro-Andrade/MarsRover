using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
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
            var rover = new Rover(FacingDirection.North, new Position(0, 0));

            var expectedPosition = new Position(expectedX, expectedY);

            var command = new MoveRoverCommand
            {
                Rover = rover,
                Movements = new List<MovementType>(movements),
                Plateau = new Plateau(5, 5)
            };

            var commandHandler = new MoveRoverCommandHandler();

            await commandHandler.Handle(command, CancellationToken.None);

            rover.Position.Should().Be(expectedPosition);
        }

        [Theory]
        [InlineData(MovementType.Left, MovementType.Forward)] //off-grid (-1, 0)
        [InlineData(MovementType.Left, MovementType.Left, MovementType.Forward)] //off-grid (0, -1)
        [InlineData(MovementType.Forward, MovementType.Forward, MovementType.Forward)] //off-grid (0, 3)
        [InlineData(MovementType.Forward, MovementType.Forward, MovementType.Left, MovementType.Forward)] // off-grid (-1, 2)
        [InlineData(MovementType.Forward, MovementType.Forward, MovementType.Right, MovementType.Forward, MovementType.Forward, MovementType.Forward)] //off-grid (3, 2)
        [InlineData(MovementType.Forward, MovementType.Forward, MovementType.Right, MovementType.Forward, MovementType.Forward, MovementType.Left, MovementType.Forward)] //off-grid (2, 3)
        [InlineData(MovementType.Right, MovementType.Forward, MovementType.Forward, MovementType.Forward)] //off-grid (3, 0)
        [InlineData(MovementType.Right, MovementType.Forward, MovementType.Forward, MovementType.Right, MovementType.Forward)] //off-grid (2, -1)
        public async Task Should_stop_moving_if_the_next_movement_is_off_grid(params MovementType[] movements)
        {
            var rover = new Rover(FacingDirection.North, new Position(0, 0));

            var command = new MoveRoverCommand
            {
                Rover = rover,
                Movements = new List<MovementType>(movements),
                Plateau = new Plateau(2, 2)
            };

            var commandHandler = new MoveRoverCommandHandler();

            Func<Task> commandAct = async () =>
            {
                await commandHandler.Handle(command, CancellationToken.None);
            };

            await commandAct.Should().ThrowAsync<OffGridMovementException>();
        }
    }
}
