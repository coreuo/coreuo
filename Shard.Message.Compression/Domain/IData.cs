﻿namespace Shard.Message.Compression.Domain
{
    public interface IData
    {
        byte[] Value { get; }

        int Offset { get; set; }

        int Length { get; set; }
    }
}
