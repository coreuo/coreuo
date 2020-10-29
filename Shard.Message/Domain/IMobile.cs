using Shard.Message.Domain.Incoming;
using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IMobile<TMobileEquip, TSkillInfo, TMap> :
        ICharacterInfo, 
        ILoginConfirm, 
        IMobileIncoming<TMobileEquip>, 
        IMobileLight, 
        IMobileStatus, 
        IMobileUpdate, 
        IMoveNotoriety, 
        ISkillList<TSkillInfo>, 
        ICharacterCreation,
        ICharacterLogin,
        IServerChange<TMap>,
        IMobileAttributes,
        IMobilePaperDoll,
        IProfileResponse
        where TMobileEquip : IMobileEquip
        where TSkillInfo : ISkill
        where TMap : IMap
    {
    }
}
