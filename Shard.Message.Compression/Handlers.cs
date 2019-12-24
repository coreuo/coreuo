using Shard.Message.Compression.Domain;

namespace Shard.Message.Compression
{
    public static class Handlers<TState, TData>
        where TState : IState<TData>
        where TData : IData, new()
    {
        public static TData OnCompress(TState state, TData compressedData)
        {
            var decompressedData = state.GetBuffer();

            var decompressedDataValue = decompressedData.Value;

            Huffman.OnCompress(compressedData.Value, compressedData.Offset, compressedData.Length, ref decompressedDataValue, 0, out var decompressedDataLength);

            decompressedData.Length = decompressedDataLength;

            state.BufferQueue.Enqueue(compressedData);

            return decompressedData;
        }
    }
}
