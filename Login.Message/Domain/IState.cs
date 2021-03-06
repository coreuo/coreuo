﻿using System;
using Login.Message.Domain.Incoming;

namespace Login.Message.Domain
{
    public interface IState<TData> :
        IClientConnect,
        IAccountLogin,
        IHardwareInfo,
        IShardSelect
        where TData : IData, new()
    {
        TData GetBuffer();

        void Send(TData data);

        void Output(string text);

        internal void Write(byte id, int size, Action<IData> message)
        {
            Info($"0x{id:X2} {message.Method.Name}");

            var data = GetBuffer();

            data.Length = size;

            data.Write(0, id);

            data.Write(1, (short)size);

            message(data);

            Send(data);
        }

        private void Info(string text)
        {
            Output($"Message: {text}");
        }
    }
}
