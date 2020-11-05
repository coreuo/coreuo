namespace Shard.Message.Domain.Outgoing
{
    public interface ISoundPlay
    {
        byte SoundMode { get; }

        ushort SoundId { get; set; }

        ushort SoundVolume { get; set; }

        internal void WriteSoundPlay(IData data)
        {
            data.Write(1, SoundMode);

            data.Write(2, SoundId);

            data.Write(4, SoundVolume);
        }
    }
}
