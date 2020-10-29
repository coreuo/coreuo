namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;

    public class Skill : Shard.Message.Domain.ISkill
    {
        public ushort Id
        {
            get => Property.OnGet<ushort>(this, nameof(Id));
            set => Property.OnSet(this, nameof(Id), value);
        }

        public ushort Value
        {
            get => Property.OnGet<ushort>(this, nameof(Value));
            set => Property.OnSet(this, nameof(Value), value);
        }

        public ushort Base
        {
            get => Property.OnGet<ushort>(this, nameof(Base));
            set => Property.OnSet(this, nameof(Base), value);
        }

        public byte Lock
        {
            get => Property.OnGet<byte>(this, nameof(Lock));
            set => Property.OnSet(this, nameof(Lock), value);
        }

        public ushort Cap
        {
            get => Property.OnGet<ushort>(this, nameof(Cap));
            set => Property.OnSet(this, nameof(Cap), value);
        }
    }
}
