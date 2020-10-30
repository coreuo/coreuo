using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Launcher.Domain
{
    using ThreadHandlers = Thread.Runner.Handlers;
    using NetworkListenerHandlers = Network.Listener.Handlers<LoginState>;
    using NetworkStateHandlers = Network.State.Handlers<Data>;
    using NetworkServerHandlers = Network.Server.Handlers<LoginState, Data>;
    using LoginMessageHandlers = Login.Message.Handlers<LoginServer, LoginState, Data, ShardServer>;
    using LoginEncryptionHandlers = Login.Encryption.Handlers<LoginState, Data>;
    using LoginServerHandlers = Login.Server.Handlers<LoginServer, LoginState, ShardServer>;

    public class LoginServer :
        Thread.Runner.Domain.IThread,
        Network.Listener.Domain.IListener<LoginState>,
        Network.Server.Domain.IServer<LoginState, Data>,
        Login.Message.Domain.IServer<LoginState, Data, ShardServer>,
        Login.Server.Domain.IServer<LoginState, ShardServer>
    {
        public LoginServer(ShardServer mainServer)
        {
            Shards = new List<ShardServer>{mainServer};

            mainServer.ThreadStop = () => ThreadHandlers.Stop(this);
        }

        public string Identity { get; set; } = nameof(LoginServer);

        public string IpAddress { get; set; } = "127.0.0.1";

        public int Port { get; set; } = 12593;

        public bool Locked { get; set; }

        public bool Running { get; set; }

        public DateTime DateTime { get; set; }

        public Socket Socket { get; set; }

        public EndPoint EndPoint { get; set; }

        public ConcurrentQueue<LoginState> ListenQueue { get; set; } = new ConcurrentQueue<LoginState>();
        
        public bool Listening { get; set; }

        public List<LoginState> States { get; set; } = new List<LoginState>();

        public Random Random { get; set; } = new Random();

        public List<ShardServer> Shards { get; set; }

        public Action ThreadStart => () => NetworkListenerHandlers.Start(this);

        public Action ThreadUnlock => () =>
        {
            NetworkListenerHandlers.Stop(this);

            NetworkServerHandlers.Stop(this);
        };

        public Action ThreadSlice => () => NetworkServerHandlers.Slice(this);

        public Action ThreadStop => () => Shards.ForEach(ThreadHandlers.Stop);

        public Action<LoginState> StateStart => NetworkStateHandlers.Start;

        public Action<LoginState> StateStop => NetworkStateHandlers.Stop;

        public Action<LoginState, Data> DataReceived => (state, data) => LoginMessageHandlers.Received(this, state, data);

        public Action<LoginState, Data> Decrypt => LoginEncryptionHandlers.Decrypt;

        public Action<LoginState> ClientConnect => LoginEncryptionHandlers.ClientConnect;

        public Action<LoginState> AccountLogin => state => LoginServerHandlers.AccountLogin(this, state);

        public Action<LoginState> ShardSelect => state => LoginServerHandlers.ShardSelect(this, state);

        public Action<LoginState> HardwareInfo => state => { };

        public Action<LoginState> ShardList => state => LoginMessageHandlers.ShardList(this, state);

        public Action<LoginState> ShardServer => state => LoginMessageHandlers.ShardServer(this, state);

        public Action<string> Output => text => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");
    }
}
