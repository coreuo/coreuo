namespace Launcher.Domain
{
    public class Property :
        Shard.Save.Domain.IProperty
    {
        public int Permission { get; set; }

        public object Instance { get; set; }

        public string Name { get; set; }

        public object Value { get; set; }

        public override string ToString() => $"{Instance.GetType().Name}.{Name} = {Value}";
    }
}
