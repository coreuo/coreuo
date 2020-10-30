namespace Shard.Validation.Domain
{
    public interface IValidation
    {
        int Permission { get; set; }

        object Instance { get; set; }

        string Property { get; set; }

        object Value { get; set; }
    }
}
