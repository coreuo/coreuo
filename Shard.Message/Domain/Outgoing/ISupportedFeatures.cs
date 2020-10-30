namespace Shard.Message.Domain.Outgoing
{
    public interface ISupportedFeatures
    {
        int FeatureFlags { get; set; }

        internal void WriteSupportedFeatures(IData data)
        {
            data.Write(1, (ushort)FeatureFlags);
        }
    }
}
