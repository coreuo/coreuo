using System;
using Shard.Message.Domain;
using Shard.Message.Domain.Outgoing;

namespace Shard.Message
{
    public static class Handlers<TServer, TState, TData, TMobile, TCity, TMobileEquip, TSkillInfo>
        where TServer : IServer<TState, TData, TMobile, TCity, TMobileEquip, TSkillInfo>
        where TState : IState<TData, TMobile, TMobileEquip, TSkillInfo>
        where TData : IData, new()
        where TMobile : IMobile<TMobileEquip, TSkillInfo>, new()
        where TCity : ICityInfo
        where TMobileEquip : IMobileEquip
        where TSkillInfo : ISkill
    {
        public static void OnReceived(TServer server, TState state, TData data)
        {
            while (data.Offset < data.Length)
            {
                var size = server.Read(state, data);

                data.Offset += size;
            }
        }

        public static void OnClientVersionRequest(TState state)
        {
            state.Write(0xBD, 3, state.WriteClientVersionRequest);
        }

        public static void OnServerTime(TServer server, TState state)
        {
            state.Write(0x5B, 4, server.WriteCurrentServerTime);
        }

        public static void OnEncryptionRequest(TState state)
        {
            state.Write(0xE3, 7 + state.EncryptionBase.Length + 4 + state.EncryptionPrime.Length + 4 + state.EncryptionPublicKey.Length + 4 + 4 + state.EncryptionIv.Length, state.WriteEncryptionRequest, false);
        }

        public static void OnGlobalLight(TServer server, TState state)
        {
            state.Write(0x4F, 2, server.WriteGlobalLight);
        }

        public static void OnCharacterList(TServer server, TState state)
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

        public static void OnLoginComplete(TState state)
        {
            state.Write(0x55, 1, state.LoginComplete);
        }

        public static void OnLoginConfirm(TState state)
        {
            state.Write(0x1B, 37, state.Mobile.WriteLoginConfirm);
        }

        public static void OnMobileIncoming(TState state, TMobile mobile)
        {
            state.Write(0x78, 18 + mobile.EquipmentSize() + 1, mobile.WriteMobileIncoming);
        }

        public static void OnMobileLight(TState state, TMobile mobile)
        {
            state.Write(0x4E, 6, mobile.WriteMobileLight);
        }

        public static void OnMobileStatus(TState state, TMobile mobile)
        {
            state.Write(0x11, 167, mobile.WriteMobileStatus);
        }

        public static void OnMobileUpdate(TState state, TMobile mobile)
        {
            state.Write(0x20, 19, mobile.WriteMobileUpdate);
        }

        public static void OnMoveResponse(TState state)
        {
            state.Write(0x22, 3, state.WriteMoveResponse);
        }

        public static void OnPingResponse(TState state)
        {
            state.Write(0x73, 2, state.WritePingResponse);
        }

        public static void OnSeasonChange(TState state)
        {
            state.Write(0xBC, 3, state.WriteSeasonChange);
        }

        public static void OnSkillInfo(TState state, TMobile mobile)
        {
            state.Write(0x3A, 6 + mobile.Skills.Count * 9, mobile.WriteSkillList);
        }

        public static void OnSupportedFeatures(TServer server, TState state)
        {
            state.Write(0xB9, 3, server.WriteSupportedFeatures);
        }

        public static void OnWarMode(TState state)
        {
            state.Write(0x72, 5, state.WriteWarMode);
        }

        public static void OnExtendedData(TState state, int size, Action<TData> writer, string writerName)
        {
            state.GenericWrite(0xBF, size, writer, writerName: writerName);
        }
    }
}
