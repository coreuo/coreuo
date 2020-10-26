using Login.Encryption.Domain;

namespace Login.Encryption
{
    public static class Handlers<TState, TData>
        where TState : IState
        where TData : IData
    {
        public static void OnDecrypt(TState state, TData data)
        {
            if (!state.Encrypted)
                return;

            state.OnDecrypt(data.Value, data.Offset, data.Length);
        }

        public static void OnClientConnect(TState state)
        {
            state.OnInitialize();
        }
    }
}
