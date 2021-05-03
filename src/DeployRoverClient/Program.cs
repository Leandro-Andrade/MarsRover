using System;
using System.Threading.Tasks;
using Api;
using Api.Dtos;
using Application;
using Microsoft.Extensions.DependencyInjection;

namespace DeployRoverClient
{
    class Program
    {
        static ServiceProvider _serviceProvider;

        static async Task Main(string[] args)
        {
            RegisterServices();

            Console.WriteLine("Welcome to Mars Control Center!");

            string input;

            try
            {
                Console.WriteLine("Please inform the size of the plateau [Width] [Length] (e.g. 4 5)");
                input = Console.ReadLine();

                var newMissionDto = new NewMissionDto
                {
                    Plateau = input
                };

                var mission = _serviceProvider.GetRequiredService<IMission>();

                do
                {
                    Console.WriteLine(
                        "Please inform the position you want the rover to land [X] [Y] [Facing Direction] (e.g. 0 0 N)");

                    input = Console.ReadLine();
                    string rover = input;

                    Console.WriteLine("Please inform the directions you want the rover to go (e.g. MML)");
                    input = Console.ReadLine();
                    string directions = input;

                    newMissionDto.Rovers.Add(new LaunchRoverDto
                    {
                        StartPosition = rover,
                        Movements = directions
                    });

                    Console.WriteLine(
                        "Hit [ENTER] to include more rovers, or type 'ok' to " +
                        "launch the rovers and finish the application");

                    input = Console.ReadLine();

                } while (input != "ok");

                await mission.Start(newMissionDto);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nMission accomplished!\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            finally
            {
                DisposeServices();
            }
        }

        private static void RegisterServices()
        {
            _serviceProvider = new ServiceCollection()
                .AddApplicationDependencies()
                .AddApiDependencies()
                .BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            _serviceProvider?.Dispose();
        }
    }
}
