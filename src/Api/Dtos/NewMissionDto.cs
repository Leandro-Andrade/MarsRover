using System.Collections.Generic;

namespace Api.Dtos
{
    public class NewMissionDto
    {
        public string Plateau { get; set; }
        public List<LaunchRoverDto> Rovers { get; set; }

        public NewMissionDto()
        {
            Rovers = new List<LaunchRoverDto>();
        }
    }
}