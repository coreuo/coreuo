using System;
using System.Linq;
using Shard.Message.Domain;
using Shard.Message.Domain.Outgoing;

namespace Shard.Message
{
    public static class Handlers<TServer, TState, TData, TEntity, TMobile, TCity, TItem, TSkillInfo, TAttribute>
        where TServer : IServer<TState, TData, TMobile, TCity, TItem, TSkillInfo>
        where TState : IState<TData, TMobile, TItem, TSkillInfo>
        where TEntity : IEntity<TAttribute, TItem>
        where TData : IData, new()
        where TMobile : IMobile<TItem, TSkillInfo>, new()
        where TCity : ICityInfo
        where TItem : IItem
        where TSkillInfo : ISkill
        where TAttribute : IAttribute
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
            state.Write(0xBD, 3, state.WriteClientVersionRequest);
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
            state.Write(0x55, 1, state.LoginComplete);
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

        public static void WarMode(TState state)
        {
            state.Write(0x72, 5, state.WriteWarMode);
        }

        public static void ExtendedData(TState state, int size, Action<TData> writer, string writerName)
        {
            state.GenericWrite(0xBF, size, writer, writerName: writerName);
        }

        /*public static void ServerChange(TState state, TMobile mobile)
        {
            state.Write(0x76, 16, mobile.WriteServerChange);
        }*/

        public static void AttributeList(TState state, TEntity entity)
        {
            state.Write(0xD6, 15 + entity.GetAttributesSizeList().Sum(e => e.size) + 4, entity.WriteAttributeList);
        }

        public static void AttributeInfo(TState state, TEntity entity)
        {
            state.Write(0xDC, 9, entity.WriteAttributeInfo);
        }

        /*public static void MobileAttributes(TState state, TMobile mobile)
        {
            state.Write(0x2D, 17, mobile.WriteMobileAttributes);
        }*/

        public static void OpenPaperDoll(TState state, TMobile mobile)
        {
            state.Write(0x88, 66, data =>
            {
                mobile.WriteMobilePaperDoll(data);

                state.WriteOpenPaperDoll(data);

            }, writerName: nameof(state.WriteOpenPaperDoll));
        }

        public static void ProfileResponse(TState state, TMobile mobile)
        {
            state.Write(0xB8, 7 + mobile.ProfileHeader.Length + 1 + 2 * mobile.ProfileFooter.Length + 2 + 2 * mobile.ProfileBody.Length + 2, mobile.WriteProfileResponse);
        }

        public static void EntityDisplay(TState state, TEntity entity)
        {
            state.Write(0x24, 7, entity.WriteEntityDisplay);
        }

        public static void EntityContent(TState state, TEntity entity)
        {
            state.Write(0x3C, 5 + entity.Items.Count * 20, entity.WriteEntityContent);
        }
    }
}
