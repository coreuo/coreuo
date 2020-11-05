using System;
using Shard.Message.Domain.Incoming;
using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IState<TData, TMobile, TItem, TEntity, TAttribute, TSkillInfo> :
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
        IEntityQuery,
        IEntityUse,
        IPaperDollOpen,
        IProfileRequest,
        IItemPick,
        ISoundPlay,
        IItemPlace,
        IItemWear
        where TData : IData, new()
        where TMobile : IMobile<TItem, TSkillInfo>
        where TAttribute : IAttribute
        where TItem : IItem<TAttribute, TItem, TEntity>
        where TEntity : IEntity<TAttribute, TItem, TEntity>
        where TSkillInfo : ISkill
    {
        Func<TData> GetBuffer { get; }

        Func<TData, TData> Compress { get; }

        Action<TData> Send { get; }

        Action<string> Output { get; }

        internal void Write(byte id, int size, Action<IData> writer = null, bool compress = true, string writerName = null)
        {
            GenericWrite(id, size, data => writer?.Invoke(data), compress, writerName ?? writer?.Method.Name);
        }

        internal void GenericWrite(byte id, int size, Action<TData> writer = null, bool compress = true, string writerName = null)
        {
            Info($"0x{id:X2} {writerName ?? writer?.Method.Name}");

            var data = GetBuffer();

            data.Length = size;

            data.Write(0, id);

            if (size > 2) data.Write(1, (short)size);

            writer?.Invoke(data);

            if (compress) data = Compress(data);

            Send(data);
        }

        private void Info(string text)
        {
            Output($"Message: {text}");
        }
    }
}
