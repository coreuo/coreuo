namespace Launcher.Domain
{
    public class Validation :
        Shard.Validation.Domain.IValidation
    {
        public int Permission { get; set; }

        public object Instance { get; set; }

        public string Property { get; set; }

        public object Value { get; set; }
    }
}
