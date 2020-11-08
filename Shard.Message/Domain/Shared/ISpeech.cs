namespace Shard.Message.Domain.Shared
{
    public interface ISpeech
    {
        byte SpeechType { get; set; }

        ushort SpeechFont { get; set; }

        string SpeechLanguage { get; set; }

        public string SpeechText { get; set; }
    }
}
