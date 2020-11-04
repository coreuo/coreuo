using System.Threading.Tasks;
using Launcher.Domain;

var shardSave = new ShardSave();

var shardServer = shardSave.Load();

var loginServer = new LoginServer(shardServer);

while (true)
{
    Thread.Runner.Handlers.Start(shardServer);

    Thread.Runner.Handlers.Start(loginServer);

    while (shardServer.Running || loginServer.Running)
    {
        await Task.Delay(1000);

        shardSave.Process();
    }
}