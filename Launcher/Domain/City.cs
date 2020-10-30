namespace Launcher.Domain
{
    using Property = Shard.Validation.Handlers<Validation>;

    public class City : Shard.Message.Domain.Outgoing.ICityInfo
    {
        public string Name
        {
            get => Property.Get<string>(this, nameof(Name));
            set => Property.Set(this, nameof(Name), value);
        }

        public string Town
        {
            get => Property.Get<string>(this, nameof(Town));
            set => Property.Set(this, nameof(Town), value);
        }

        public City()
        {
            Name = default;
            Town = default;
        }
    }
}