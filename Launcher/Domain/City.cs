namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;

    public class City : Shard.Message.Domain.Outgoing.ICityInfo
    {
        public string Name
        {
            get => Property.OnGet<string>(this, nameof(Name));
            set => Property.OnSet(this, nameof(Name), value);
        }

        public string Town
        {
            get => Property.OnGet<string>(this, nameof(Town));
            set => Property.OnSet(this, nameof(Town), value);
        }

        public City()
        {
            Name = default;
            Town = default;
        }
    }
}