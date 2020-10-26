namespace Shard.Message.Domain.Outgoing
{
    public interface ISupportedFeatures
    {
        int FeatureFlags { get; set; }

        internal void OnWriteSupportedFeatures(IData data)
        {
            data.OnWrite(1, (ushort)FeatureFlags);
        }
    }
}
