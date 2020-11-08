﻿using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Outgoing
{
    public interface ISpeechResponse : 
        IHue,
        ISpeech
    {
        ushort SpeechGraphic { get; set; }

        internal void WriteSpeechResponse(IData data)
        {
            data.Write(7, SpeechGraphic);

            data.Write(9, SpeechType);

            data.Write(10, Hue);

            data.Write(12, SpeechFont);

            data.WriteAscii(14, SpeechLanguage, 4);

            data.WriteBigUnicodeTerminated(48, SpeechText);
        }
    }
}