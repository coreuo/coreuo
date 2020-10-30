using Login.Encryption.Domain;

namespace Login.Encryption
{
    public static class Handlers<TState, TData>
        where TState : IState
        where TData : IData
    {
        public static void Decrypt(TState state, TData data)
        {
            if (!state.Encrypted)
                return;

            state.Decrypt(data.Value, data.Offset, data.Length);
        }

        public static void ClientConnect(TState state)
        {
            state.Initialize();
        }
    }
}
