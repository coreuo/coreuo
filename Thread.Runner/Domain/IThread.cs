using System;

namespace Thread.Runner.Domain
{
    public interface IThread
    {
        bool Locked { get; set; }

        bool Running { get; set; }

        DateTime DateTime { get; set; }

        public Action ThreadStart { get; }

        public Action ThreadUnlock { get; }

        public Action ThreadSlice { get; }

        public Action ThreadStop { get; }

        Action<string> Output { get; }

        internal void OnRun()
        {
            OnInfo("started");

            ThreadStart();

            if(Locked) OnInfo("locked");

            while (Locked)
            {
                OnSlice();
            }

            OnInfo("unlocked");

            ThreadUnlock();

            while (Running)
            {
                OnSlice();
            }

            OnInfo("stopped");

            ThreadStop();
        }

        private void OnSlice()
        {
            DateTime = DateTime.Now;

            ThreadSlice();

            OnWait();
        }

        private void OnInfo(string text)
        {
            Output($"Thread: {text}");
        }

        private static void OnWait()
        {
            System.Threading.Thread.Sleep(1);
        }
    }
}
