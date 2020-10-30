using Network.State.Domain;

namespace Network.State
{
    public static class Handlers<TData>
        where TData : IData, new()
    {
        public static void Start(IReceiver<TData> receiver)
        {
            receiver.Locked = true;

            receiver.Receiving = true;

            receiver.BeginReceive();
        }

        public static void Send(ISender<TData> sender, TData data)
        {
            if (!sender.Locked)
                return;

            sender.Sending++;

            sender.BeginSend(data);
        }

        public static void Stop(IState<TData> state)
        {
            if (!state.Locked || state.Sending < 0 || !state.Receiving)
                return;

            state.Locked = false;

            state.BeginClose();
        }

        public static TData GetBuffer(IState<TData> state)
        {
            var data = state.BufferQueue.TryDequeue(out var buffer) ? buffer : new TData();

            data.Offset = 0;

            data.Length = data.Value.Length;

            return data;
        }
    }
}
