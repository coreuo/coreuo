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

        public int? Port { get; set; } = 2593;

        public bool Locked { get; set; }

        public bool Running { get; set; }

        public DateTime DateTime { get; set; }

        public Socket Socket { get; set; }

        public EndPoint EndPoint { get; set; }

        public ConcurrentQueue<LoginState> ListenQueue { get; } = new();
        
        public bool Listening { get; set; }

        public List<LoginState> States { get; } = new();

        public Random Random { get; } = new();

        public List<ShardServer> Shards { get; }

        public void ThreadStart() => NetworkListenerHandlers.Start(this);

        public void ThreadUnlock()
        {
            NetworkListenerHandlers.Stop(this);

            NetworkServerHandlers.Stop(this);
        }

        public void ThreadSlice() => NetworkServerHandlers.Slice(this);

        public Action ThreadStop => () => Shards.ForEach(ThreadHandlers.Stop);

        public void StateStart(LoginState state) => NetworkStateHandlers.Start(state);

        public void StateStop(LoginState state) => NetworkStateHandlers.Stop(state);

        public void DataReceived(LoginState state, Data data) => LoginMessageHandlers.Received(this, state, data);

        public void Decrypt(LoginState state, Data data) => LoginEncryptionHandlers.Decrypt(state, data);

        public void ClientConnect(LoginState state) => LoginEncryptionHandlers.ClientConnect(state);

        public void AccountLogin(LoginState state) => LoginServerHandlers.AccountLogin(this, state);

        public void ShardSelect(LoginState state) => LoginServerHandlers.ShardSelect(this, state);

        public void HardwareInfo(LoginState state) { }

        public void ShardList(LoginState state) => LoginMessageHandlers.ShardList(this, state);

        public void ShardServer(LoginState state) => LoginMessageHandlers.ShardServer(this, state);

        public void Output(string text) => Console.WriteLine($"[{DateTime.Now:O}] {Identity}.{text}");
    }
}
