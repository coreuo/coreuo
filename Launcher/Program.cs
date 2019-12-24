using Launcher.Domain;

namespace Launcher
{
    internal class Program
    {
        private static void Main()
        {
            var shardServer = new ShardServer();

            var loginServer = new LoginServer(shardServer);

            Thread.Runner.Handlers.OnStart(shardServer);

            Thread.Runner.Handlers.OnStart(loginServer);
        }
    }
}