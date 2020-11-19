using Shard.Message.Domain.Outgoing;

namespace Shard.Message.Domain
{
    public interface IMobile<TMobileEquip, TSkillInfo> :
        ICharacterInfo, 
        ILoginConfirm,
        IMobileIncoming<TMobileEquip>, 
        IMobileLight, 
        IMobileStatus, 
        IMobileUpdate, 
        IMoveNotoriety, 
        ISkillList<TSkillInfo>, 
        IServerChange,
        IMobileAttributes,
        IMobilePaperDoll,
        IProfileResponse,
        IWarModeResponse,
        IMobileMoving,
        IMobileSpeech
        where TMobileEquip : IMobileItem
        where TSkillInfo : ISkill
    {
    }
}
