﻿using System;
using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface IEntityContentItem<out TEntity> :
        ISerialGet,
        IGraphics,
        IAmount,
        ITarget,
        IHue,
        IGridIndex,
        IParent<TEntity>
        where TEntity : ISerialGet
    {
        internal void WriteEntityContentItem(int offset, int currentSize, IData data)
        {
            if (Parent == null) throw new InvalidOperationException($"Unknown entity content item ({this}) parent.");

            data.Write(offset + currentSize, Serial);

            data.Write(offset + currentSize + 4, Graphic);

            data.Write(offset + currentSize + 6, (byte)0);

            data.Write(offset + currentSize + 7, Amount);

            data.Write(offset + currentSize + 9, LocationX);

            data.Write(offset + currentSize + 11, LocationY);

            data.Write(offset + currentSize + 13, GridIndex);

            data.Write(offset + currentSize + 14, Parent.Serial);

            data.Write(offset + currentSize + 18, Hue);
        }
    }
}
