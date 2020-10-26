using System;
using System.Linq;
using Shard.Message.Domain;
using Shard.Message.Domain.Outgoing;

namespace Shard.Message
{
    public static class Handlers<TServer, TState, TData, TEntity, TMobile, TCity, TMobileEquip, TSkillInfo, TMap, TProperty>
        where TServer : IServer<TState, TData, TMobile, TCity, TMobileEquip, TSkillInfo, TMap>
        where TState : IState<TData, TMobile, TMobileEquip, TSkillInfo, TMap>
        where TEntity : IEntity<TProperty>
        where TData : IData, new()
        where TMobile : IMobile<TMobileEquip, TSkillInfo, TMap>, new()
        where TCity : ICityInfo
        where TMobileEquip : IMobileEquip
        where TSkillInfo : ISkill
        where TMap : IMap
        where TProperty : IProperty
    {
        public static void OnReceived(TServer server, TState state, TData data)
        {
            while (data.Offset < data.Length)
            {
                var size = server.OnRead(state, data);

                data.Offset += size;
            }
        }

        public static void OnClientVersionRequest(TState state)
        {
            state.OnWrite(0xBD, 3, state.OnWriteClientVersionRequest);
        }

        public static void OnServerTime(TServer server, TState state)
        {
            state.OnWrite(0x5B, 4, server.OnWriteCurrentServerTime);
        }

        public static void OnEncryptionRequest(TState state)
        {
            state.OnWrite(0xE3, 7 + state.EncryptionBase.Length + 4 + state.EncryptionPrime.Length + 4 + state.EncryptionPublicKey.Length + 4 + 4 + state.EncryptionIv.Length, state.OnWriteEncryptionRequest, false);
        }

        public static void OnGlobalLight(TServer server, TState state)
        {
            state.OnWrite(0x4F, 2, server.OnWriteGlobalLight);
        }

        public static void OnCharacterList(TServer server, TState state)
        {
            var characterListSize = 4 + Math.Max(state.Characters.Count, 7) * 60;

            var cityListSize = 1 + server.Cities.Count * 63;

            state.OnWrite(0xA9, characterListSize + cityListSize + 4 + 28, data =>
            {
                state.OnWriteCharacterList(data);

                server.OnWriteCityList(characterListSize, data);

                server.OnWriteCharacterFeatures(characterListSize, cityListSize, data);

            }, writerName: nameof(state.OnWriteCharacterList));
        }

        public static void OnLoginComplete(TState state)
        {
            state.OnWrite(0x55, 1, state.OnLoginComplete);
        }

        public static void OnLoginConfirm(TState state, TMobile mobile)
        {
            state.OnWrite(0x1B, 37, mobile.OnWriteLoginConfirm);
        }

        public static void OnMobileIncoming(TState state, TMobile mobile)
        {
            state.OnWrite(0x78, 18 + mobile.OnEquipmentSize() + 1, mobile.OnWriteMobileIncoming);
        }

        public static void OnMobileLight(TState state, TMobile mobile)
        {
            state.OnWrite(0x4E, 6, mobile.OnWriteMobileLight);
        }

        public static void OnMobileStatus(TState state, TMobile mobile)
        {
            state.OnWrite(0x11, 167, mobile.OnWriteMobileStatus);
        }

        public static void OnMobileUpdate(TState state, TMobile mobile)
        {
            state.OnWrite(0x20, 19, mobile.OnWriteMobileUpdate);
        }

        public static void OnMoveResponse(TState state, TMobile mobile)
        {
            state.OnWrite(0x22, 3, data=>
            {
                state.OnWriteMoveResponse(data);

                mobile.OnWriteMoveNotoriety(data);

            }, writerName: nameof(state.OnWriteMoveResponse));
        }

        public static void OnPingResponse(TState state)
        {
            state.OnWrite(0x73, 2, state.OnWritePingResponse);
        }

        public static void OnSeasonChange(TState state)
        {
            state.OnWrite(0xBC, 3, state.OnWriteSeasonChange);
        }

        public static void OnSkillInfo(TState state, TMobile mobile)
        {
            state.OnWrite(0x3A, 6 + mobile.Skills.Count * 9, mobile.OnWriteSkillList);
        }

        public static void OnSupportedFeatures(TServer server, TState state)
        {
            state.OnWrite(0xB9, 3, server.OnWriteSupportedFeatures);
        }

        public static void OnWarMode(TState state)
        {
            state.OnWrite(0x72, 5, state.OnWriteWarMode);
        }

        public static void OnExtendedData(TState state, int size, Action<TData> writer, string writerName)
        {
            state.OnGenericWrite(0xBF, size, writer, writerName: writerName);
        }

        public static void OnServerChange(TState state, TMobile mobile)
        {
            state.OnWrite(0x76, 16, mobile.OnWriteServerChange);
        }

        public static void OnPropertyList(TState state, TEntity entity)
        {
            state.OnWrite(0xD6, 15 + entity.OnGetPropertiesSizeList().Sum(e => e.size) + 4, entity.OnWritePropertyList);
        }

        public static void OnPropertyInfo(TState state, TEntity entity)
        {
            state.OnWrite(0xDC, 9, entity.OnWritePropertyInfo);
        }

        public static void OnMobileAttributes(TState state, TMobile mobile)
        {
            state.OnWrite(0x2D, 17, mobile.OnWriteMobileAttributes);
        }
    }
}
