using Network.State.Domain;

namespace Network.State
{
    public static class Handlers<TData>
        where TData : IData, new()
    {
        public static void OnStart(IReceiver<TData> receiver)
        {
            receiver.Locked = true;

            receiver.Receiving = true;

            receiver.OnBeginReceive();
        }

        public static void OnSend(ISender<TData> sender, TData data)
        {
            if (!sender.Locked)
                return;

            sender.Sending++;

            sender.OnBeginSend(data);
        }

        public static void OnStop(IState<TData> state)
        {
            if (!state.Locked || state.Sending < 0 || !state.Receiving)
                return;

            state.Locked = false;

            state.OnBeginClose();
        }

        public static TData OnGetBuffer(IState<TData> state)
        {
            var data = state.BufferQueue.TryDequeue(out var buffer) ? buffer : new TData();

            data.Offset = 0;

            data.Length = data.Value.Length;

            return data;
        }
    }
}
