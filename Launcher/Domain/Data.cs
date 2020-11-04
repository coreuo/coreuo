using System.ComponentModel.DataAnnotations.Schema;

namespace Launcher.Domain
{
    [NotMapped]
    public class Data :
        Network.State.Domain.IData,
        Network.Server.Domain.IData,
        Login.Message.Domain.IData,
        Login.Encryption.Domain.IData,
        Shard.Message.Domain.IData,
        Shard.Message.Extended.Domain.IData,
        Shard.Message.Compression.Domain.IData
    {
        public byte[] Value { get; } = new byte[2048];

        public int Offset { get; set; }

        public int Length { get; set; }

        public int ExtendedOffset { get; set; }

        public int ExtendedLength { get; set; }
    }
}
