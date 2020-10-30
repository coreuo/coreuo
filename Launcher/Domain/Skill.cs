namespace Launcher.Domain
{
    using Property = Shard.Server.Validation.Handlers<Validation>;

    public class Skill : Shard.Message.Domain.ISkill
    {
        public ushort Id
        {
            get => Property.Get<ushort>(this, nameof(Id));
            set => Property.Set(this, nameof(Id), value);
        }

        public ushort Value
        {
            get => Property.Get<ushort>(this, nameof(Value));
            set => Property.Set(this, nameof(Value), value);
        }

        public ushort Base
        {
            get => Property.Get<ushort>(this, nameof(Base));
            set => Property.Set(this, nameof(Base), value);
        }

        public byte Lock
        {
            get => Property.Get<byte>(this, nameof(Lock));
            set => Property.Set(this, nameof(Lock), value);
        }

        public ushort Cap
        {
            get => Property.Get<ushort>(this, nameof(Cap));
            set => Property.Set(this, nameof(Cap), value);
        }
    }
}
