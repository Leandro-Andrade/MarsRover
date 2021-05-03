using System.Threading.Tasks;
using Api.Dtos;
using Application.Parsers;
using Application.Rovers.Commands;
using MediatR;

namespace Api
{
    public class Mission : IMission
    {
        private readonly ISender _mediator;

        public Mission(ISender mediator)
        {
            _mediator = mediator;
        }

        public async Task Start(NewMissionDto newMissionDto)
        {
            var plateau = new PlateauParser().Parse(newMissionDto.Plateau);

            foreach (var rover in newMissionDto.Rovers)
            {
                var moveRoverCommand = new MoveRoverCommand
                {
                    Plateau = plateau,
                    Rover = new RoverParser().Parse(rover.StartPosition),
                    Movements = new MovementsParser().Parse(rover.Movements)
                };

                await _mediator.Send(moveRoverCommand);
            }
        }
    }
}
