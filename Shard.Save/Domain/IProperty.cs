namespace Shard.Save.Domain
{
    public interface IProperty
    {
        int Permission { get; set; }

        object Instance { get; set; }

        string Name { get; set; }

        object Value { get; set; }
    }
}
