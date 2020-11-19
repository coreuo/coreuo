using System;

namespace Thread.Runner.Domain
{
    public interface IThread
    {
        bool Locked { get; set; }

        bool Running { get; set; }

        DateTime DateTime { set; }

        public Action ThreadStart { get; }

        public Action ThreadUnlock { get; }

        public Action ThreadSlice { get; }

        public Action ThreadStop { get; }

        Action<string> Output { get; }

        internal void Run()
        {
            Info("started");

            ThreadStart();

            if(Locked) Info("locked");

            while (Locked)
            {
                Slice();
            }

            Info("unlocked");

            ThreadUnlock();

            while (Running)
            {
                Slice();
            }

            Info("stopped");

            ThreadStop();
        }

        private void Slice()
        {
            DateTime = DateTime.Now;

            ThreadSlice();

            Wait();
        }

        private void Info(string text)
        {
            Output($"Thread: {text}");
        }

        private static void Wait()
        {
            System.Threading.Thread.Sleep(1);
        }
    }
}
