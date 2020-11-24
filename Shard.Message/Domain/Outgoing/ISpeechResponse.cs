using Shard.Message.Domain.Shared;
using System;

namespace Shard.Message.Domain.Outgoing
{
    public interface ISpeechResponse : 
        IHue,
        ISpeech
    {
        ushort SpeechGraphics { get; }

        internal void WriteSpeechResponse(IData data)
        {
            if (SpeechLanguage == null) throw new InvalidOperationException("Unknown speech language.");

            if (SpeechText == null) throw new InvalidOperationException("Unknown speech text.");

            data.Write(7, SpeechGraphics);

            data.Write(9, SpeechType);

            data.Write(10, Hue);

            data.Write(12, SpeechFont);

            data.WriteAscii(14, SpeechLanguage, 4);

            data.WriteBigUnicodeTerminated(48, SpeechText);
        }
    }
}
