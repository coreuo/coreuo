namespace Shard.Message.Domain.Outgoing
{
    public interface ISoundPlay
    {
        byte SoundMode { get; }

        ushort SoundId { get; }

        ushort SoundVolume { get; }

        internal void WriteSoundPlay(IData data)
        {
            data.Write(1, SoundMode);

            data.Write(2, SoundId);

            data.Write(4, SoundVolume);
        }
    }
}
