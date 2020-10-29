using System;
using Shard.Message.Domain.Incoming;
using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IState<TData, TMobile, TMobileEquip, TSkillInfo, TMap> :
        IAccountLogin,
        IChatRequest,
        IClientSeed,
        IEncryptionResponse,
        IMobileQuery,
        IPingRequest,
        IMoveRequest,
        ICharacterList<TMobile>,
        IClientVersionRequest,
        IEncryptionRequest,
        IMoveResponse,
        IPingResponse,
        ISeasonChange,
        IWarMode,
        IClientType,
        ILoginComplete,
        IAttributesQuery,
        IDoubleClick,
        IOpenPaperDoll,
        IRequestProfile
        where TData : IData, new()
        where TMobile : IMobile<TMobileEquip, TSkillInfo, TMap>
        where TMobileEquip : IMobileEquip
        where TSkillInfo : ISkill
        where TMap : IMap
    {
        Func<TData> GetBuffer { get; }

        Func<TData, TData> Compress { get; }

        Action<TData> Send { get; }

        Action<string> Output { get; }

        internal void OnWrite(byte id, int size, Action<IData> writer = null, bool compress = true, string writerName = null)
        {
            OnGenericWrite(id, size, data => writer?.Invoke(data), compress, writerName ?? writer?.Method.Name);
        }

        internal void OnGenericWrite(byte id, int size, Action<TData> writer = null, bool compress = true, string writerName = null)
        {
            OnInfo($"0x{id:X2} {writerName ?? writer?.Method.Name}");

            var data = GetBuffer();

            data.Length = size;

            data.OnWrite(0, id);

            if (size > 2) data.OnWrite(1, (short)size);

            writer?.Invoke(data);

            if (compress) data = Compress(data);

            Send(data);
        }

        private void OnInfo(string text)
        {
            Output($"Message: {text}");
        }
    }
}
