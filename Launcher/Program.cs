using System.Threading.Tasks;
using Launcher.Domain;

namespace Launcher
{
    internal class Program
    {
        private static async Task Main()
        {
            var shardServer = new ShardServer();

            var loginServer = new LoginServer(shardServer);

            while (true)
            {
                Thread.Runner.Handlers.Start(shardServer);

                Thread.Runner.Handlers.Start(loginServer);

                while (shardServer.Running || loginServer.Running)
                {
                    await Task.Delay(1000);
                }
            }
        }
    }
}