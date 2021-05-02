using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using MediatR;

namespace Application.Rovers.Commands
{
    public class MoveRoverCommand : IRequest
    {
        public Rover Rover { get; set; }
        public IReadOnlyCollection<MovementType> Movements { get; set; }
    }

    public class MoveRoverCommandHandler : IRequestHandler<MoveRoverCommand>
    {
        public Task<Unit> Handle(MoveRoverCommand request, CancellationToken cancellationToken)
        {
            if (request.Rover == null)
                return Task.FromResult(Unit.Value);

            foreach (var movement in request.Movements)
            {
                switch (movement)
                {
                    case MovementType.Forward:
                        MoveForward(request.Rover);
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

        private static void MoveForward(Rover rover)
        {
            switch (rover.FacingDirection)
            {
                case FacingDirection.North:
                    rover.Position = new Position(rover.Position.X, rover.Position.Y + 1);
                    break;

                case FacingDirection.South:
                    rover.Position = new Position(rover.Position.X, rover.Position.Y - 1);
                    break;

                case FacingDirection.East:
                    rover.Position = new Position(rover.Position.X + 1, rover.Position.Y);
                    break;

                case FacingDirection.West:
                    rover.Position = new Position(rover.Position.X - 1, rover.Position.Y);
                    break;
            }
        }

        private void TurnRight(Rover rover)
        {
            int newFacingDirectionDegrees = (int)rover.FacingDirection + 90;

            rover.FacingDirection = newFacingDirectionDegrees == 360
                ? FacingDirection.North
                : (FacingDirection)newFacingDirectionDegrees;
        }

        private void TurnLeft(Rover rover)
        {
            int newFacingDirectionDegrees = (int)rover.FacingDirection - 90;

            rover.FacingDirection = newFacingDirectionDegrees == -90
                ? FacingDirection.West
                : (FacingDirection)newFacingDirectionDegrees;
        }
    }
}
