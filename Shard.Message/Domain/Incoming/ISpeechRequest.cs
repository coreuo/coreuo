using System.Collections.Generic;
using Shard.Message.Domain.Shared;

namespace Shard.Message.Domain.Incoming
{
    public interface ISpeechRequest :
        IHue,
        ISpeech
    {
        List<int> KeyWords { get; set; }

        internal int ReadSpeechRequest(IData data)
        {
            var length = data.ReadUShort(1);

            SpeechType = data.ReadByte(3);

            Hue = data.ReadUShort(4);

            SpeechFont = data.ReadUShort(6);

            SpeechLanguage = data.ReadAscii(8, 4);

            SpeechText = SpeechType == 0xC0 ? ReadEncodedSpeech(data, length - 14) : data.ReadUnicode(12, length - 12);

            return length;
        }

        internal string ReadEncodedSpeech(IData data, int length)
        {
            KeyWords = new List<int>();

            var key = data.ReadUShort(12);

            var count = (key & 0xFFF0) >> 4;

            var hold = key & 0xF;

            var offset = 0;

            for (var i = 0; i < count; i++)
            {
                var even = i & 1;

                key = data.ReadUShort(14 + offset);

                if (even == 0) KeyWords.Add((hold << 8) | key >> 8);

                else KeyWords.Add((key & 0xFFF0) >> 4);

                hold = key & 0xF;

                offset += even + 1;
            }

            return data.ReadUtf8Terminated(14 + offset, length - offset);
        }
    }
}
