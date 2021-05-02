using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using MediatR;

namespace Application.Rovers.Commands
{
    public class MoveRoverCommand : IRequest
    {
        public Rover Rover { get; set; }
        public Plateau Plateau { get; set; }
        public IReadOnlyCollection<MovementType> Movements { get; set; }
    }

    public class MoveRoverCommandHandler : IRequestHandler<MoveRoverCommand>
    {
        public Task<Unit> Handle(MoveRoverCommand request, CancellationToken cancellationToken)
        {
            if (request.Rover == null || request.Plateau == null)
                return Task.FromResult(Unit.Value);

            foreach (var movement in request.Movements)
            {
                // Maybe use Strategy to clean-up all those logic?
                switch (movement)
                {
                    case MovementType.Forward:
                        MoveForward(request);
                        break;

                    case MovementType.Right:
                        TurnRight(request.Rover);
                        break;

                    case MovementType.Left:
                        TurnLeft(request.Rover);
                        break;
                }
            }

            return Task.FromResult(Unit.Value);
        }

        private static void MoveForward(MoveRoverCommand command)
        {
            Position targetPosition;
            var rover = command.Rover;
            var plateau = command.Plateau;

            switch (rover.FacingDirection)
            {
                case FacingDirection.North:
                    targetPosition = new Position(rover.Position.X, rover.Position.Y + 1);
                    if (!plateau.IsWithinBounds(targetPosition))
                    {
                        throw new OffGridMovementException(rover.Position, rover.FacingDirection);
                    }
                    rover.Position = targetPosition;
                    break;

                case FacingDirection.South:
                    targetPosition = new Position(rover.Position.X, rover.Position.Y - 1);
                    if (!plateau.IsWithinBounds(targetPosition))
                    {
                        throw new OffGridMovementException(rover.Position, rover.FacingDirection);
                    }
                    rover.Position = targetPosition;
                    break;

                case FacingDirection.East:
                    targetPosition = new Position(rover.Position.X + 1, rover.Position.Y);
                    if (!plateau.IsWithinBounds(targetPosition))
                    {
                        throw new OffGridMovementException(rover.Position, rover.FacingDirection);
                    }
                    rover.Position = targetPosition;
                    break;

                case FacingDirection.West:
                    targetPosition = new Position(rover.Position.X - 1, rover.Position.Y);
                    if (!plateau.IsWithinBounds(targetPosition))
                    {
                        throw new OffGridMovementException(rover.Position, rover.FacingDirection);
                    }
                    rover.Position = targetPosition;
                    break;
            }
        }

        private static void TurnRight(Rover rover)
        {
            int newFacingDirectionDegrees = (int)rover.FacingDirection + 90;

            rover.FacingDirection = newFacingDirectionDegrees == 360
                ? FacingDirection.North
                : (FacingDirection)newFacingDirectionDegrees;
        }

        private static void TurnLeft(Rover rover)
        {
            int newFacingDirectionDegrees = (int)rover.FacingDirection - 90;

            rover.FacingDirection = newFacingDirectionDegrees == -90
                ? FacingDirection.West
                : (FacingDirection)newFacingDirectionDegrees;
        }
    }
}
