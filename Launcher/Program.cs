using System.Threading.Tasks;
using Launcher.Domain;

using ThreadRunnerHandlers = Thread.Runner.Handlers;

var shardServer = new ShardServer();

var loginServer = new LoginServer(shardServer);

while (true)
{
    ThreadRunnerHandlers.Start(shardServer);

    ThreadRunnerHandlers.Start(loginServer);

    while (shardServer.Running || loginServer.Running)
    {
        await Task.Delay(1000);
    }
}