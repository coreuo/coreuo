﻿using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface IEntityUse : 
        ISerialSet
    {
        internal int ReadEntityUse(IData data)
        {
            Serial = data.ReadInt(1);

            return 5;
        }
    }
}
