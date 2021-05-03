using System.Threading.Tasks;
using Api.Dtos;

namespace Api
{
    public interface IMission
    {
        Task Start(NewMissionDto newMissionDto);
    }
}