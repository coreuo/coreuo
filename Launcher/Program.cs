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
                Thread.Runner.Handlers.OnStart(shardServer);

                Thread.Runner.Handlers.OnStart(loginServer);

                while (shardServer.Running || loginServer.Running)
                {
                    await Task.Delay(1000);
                }
            }
        }
    }
}