using System;
using System.Linq;
using Shard.Message.Domain;
using Shard.Message.Domain.Outgoing;

namespace Shard.Message
{
    public static class Handlers<TServer, TState, TData, TEntity, TMobile, TCity, TItem, TSkillInfo, TAttribute, TTarget>
        where TServer : IServer<TState, TData, TMobile, TCity, TItem, TEntity, TAttribute, TSkillInfo>
        where TState : IState<TData, TMobile, TItem, TEntity, TAttribute, TSkillInfo>
        where TEntity : IEntity<TAttribute, TItem, TEntity>
        where TData : IData, new()
        where TMobile : IMobile<TItem, TSkillInfo>
        where TCity : ICityInfo
        where TItem : IItem<TAttribute, TItem, TEntity>
        where TSkillInfo : ISkill
        where TAttribute : IAttribute
        where TTarget : ITarget
    {
        public static void Received(TServer server, TState state, TData data)
        {
            while (data.Offset < data.Length)
            {
                var size = server.Read(state, data);

                data.Offset += size;
            }
        }

        public static void ClientVersionRequest(TState state)
        {
            state.Write(0xBD, 3, writerName: "WriteClientVersionRequest");
        }

        public static void ServerTime(TServer server, TState state)
        {
            state.Write(0x5B, 4, server.WriteCurrentServerTime);
        }

        public static void EncryptionRequest(TState state)
        {
            state.Write(0xE3, 7 + state.EncryptionBase.Length + 4 + state.EncryptionPrime.Length + 4 + state.EncryptionPublicKey.Length + 4 + 4 + state.EncryptionIv.Length, state.WriteEncryptionRequest, false);
        }

        public static void GlobalLight(TServer server, TState state)
        {
            state.Write(0x4F, 2, server.WriteGlobalLight);
        }

        public static void CharacterList(TServer server, TState state)
        {
            var characterListSize = 4 + Math.Max(state.Characters.Count, 7) * 60;

            var cityListSize = 1 + server.Cities.Count * 63;

            state.Write(0xA9, characterListSize + cityListSize + 4 + 28, data =>
            {
                state.WriteCharacterList(data);

                server.WriteCityList(characterListSize, data);

                server.WriteCharacterFeatures(characterListSize, cityListSize, data);

            }, writerName: nameof(state.WriteCharacterList));
        }

        public static void LoginComplete(TState state)
        {
            state.Write(0x55, 1, writerName: "WriteLoginComplete");
        }

        public static void LoginConfirm(TState state, TMobile mobile)
        {
            state.Write(0x1B, 37, mobile.WriteLoginConfirm);
        }

        public static void MobileIncoming(TState state, TMobile mobile)
        {
            state.Write(0x78, 18 + mobile.EquipmentSize() + 1, mobile.WriteMobileIncoming);
        }

        public static void MobileLight(TState state, TMobile mobile)
        {
            state.Write(0x4E, 6, mobile.WriteMobileLight);
        }

        public static void MobileStatus(TState state, TMobile mobile)
        {
            state.Write(0x11, 167, mobile.WriteMobileStatus);
        }

        public static void MobileUpdate(TState state, TMobile mobile)
        {
            state.Write(0x20, 19, mobile.WriteMobileUpdate);
        }

        public static void MoveResponse(TState state, TMobile mobile)
        {
            state.Write(0x22, 3, data =>
            {
                state.WriteMoveResponse(data);

                mobile.WriteMoveNotoriety(data);

            }, writerName: nameof(state.WriteMoveResponse));
        }

        public static void PingResponse(TState state)
        {
            state.Write(0x73, 2, state.WritePingResponse);
        }

        public static void SeasonChange(TState state)
        {
            state.Write(0xBC, 3, state.WriteSeasonChange);
        }

        public static void SkillInfo(TState state, TMobile mobile)
        {
            state.Write(0x3A, 6 + mobile.Skills.Count * 9, mobile.WriteSkillList);
        }

        public static void SupportedFeatures(TServer server, TState state)
        {
            state.Write(0xB9, 3, server.WriteSupportedFeatures);
        }

        public static void WarModeResponse(TState state, TMobile mobile)
        {
            state.Write(0x72, 5, mobile.WriteWarModeResponse);
        }

        public static void ExtendedData(TState state, int size, Action<TData> writer, string writerName)
        {
            state.GenericWrite(0xBF, size, writer, writerName: writerName);
        }

        /*public static void ServerChange(TState state, TMobile mobile)
        {
            state.Write(0x76, 16, mobile.WriteServerChange);
        }*/

        public static void EntityAttributes(TState state, TEntity entity)
        {
            state.Write(0xD6, 15 + entity.GetAttributesSizeList().Sum(e => e.size) + 4, entity.WriteEntityAttributes);
        }

        public static void EntityInfo(TState state, TEntity entity)
        {
            state.Write(0xDC, 9, entity.WriteEntityInfo);
        }

        /*public static void MobileAttributes(TState state, TMobile mobile)
        {
            state.Write(0x2D, 17, mobile.WriteMobileAttributes);
        }*/

        public static void PaperDollOpen(TState state, TMobile mobile)
        {
            state.Write(0x88, 66, data =>
            {
                mobile.WriteMobilePaperDoll(data);

                state.WritePaperDollOpen(data);

            }, writerName: nameof(state.WritePaperDollOpen));
        }

        public static void ProfileResponse(TState state, TMobile mobile)
        {
            state.Write(0xB8, 7 + mobile.ProfileHeader.Length + 1 + 2 * mobile.ProfileFooter.Length + 2 + 2 * mobile.ProfileGraphics.Length + 2, mobile.WriteProfileResponse);
        }

        public static void EntityDisplay(TState state, TEntity entity)
        {
            state.Write(0x24, 7, entity.WriteEntityDisplay);
        }

        public static void EntityContent(TState state, TEntity entity)
        {
            state.Write(0x3C, 5 + entity.Items.Count * 20, entity.WriteEntityContent);
        }

        public static void EntityRemove(TState state, TEntity entity)
        {
            state.Write(0x1D, 5, entity.WriteEntityRemove);
        }

        public static void SoundPlay(TState state, TTarget target)
        {
            state.Write(0x54, 12, data =>
            {
                state.WriteSoundPlay(data);

                target.WriteSoundTarget(data);

            }, writerName: nameof(state.WriteSoundPlay));
        }

        public static void ItemPlaceApproved(TState state)
        {
            state.Write(0x29, 1, writerName: "WriteItemPlaceApproved");
        }

        public static void EntityContentItem(TState state, TItem item)
        {
            state.Write(0x25, 21, data => item.WriteEntityContentItem(1, 0, data), writerName: nameof(item.WriteEntityContentItem));
        }

        public static void ItemWorld(TState state, TItem item)
        {
            state.Write(0x1A, 14 + (item.Amount > 0 ? 2 : 0) + (item.Direction > 0 ? 1 : 0) + (item.Hue > 0 ? 2 : 0), item.WriteItemWorld);
        }

        public static void ItemWearUpdate(TState state, TItem item)
        {
            state.Write(0x2E, 15, item.WriteItemWearUpdate);
        }

        public static void MobileMoving(TState state, TMobile mobile)
        {
            state.Write(0x77, 17, mobile.WriteMobileMoving);
        }

        public static void SpeechResponse(TState state, TMobile mobile)
        {
            state.Write(0xAE, 48 + 2 * state.SpeechText?.Length ?? 0 + 2, data =>
            {
                mobile.WriteMobileSpeech(data);

                state.WriteSpeechResponse(data);

            }, writerName: nameof(state.WriteSpeechResponse));
        }

        public static void TargetRequest(TState state)
        {
            state.Write(0x6C, 19, state.WriteTargetRequest);
        }
    }
}
