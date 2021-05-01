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
        [Fact]
        public async Task Should_move_rover()
        {
            var rover = new Rover
            {
                FacingDirection = FacingDirection.North,
                Position = new Position(0, 0)
            };

            var expectedPosition = new Position(0, 1);

            var command = new MoveRoverCommand
            {
                Rover = rover,
                Movements = new List<MovementType>
                {
                    MovementType.Forward
                }
            };

            var commandHandler = new MoveRoverCommandHandler();

            await commandHandler.Handle(command, CancellationToken.None);

            rover.Position.Should().Be(expectedPosition);
        }
    }
}
