using System;

namespace Thread.Runner.Domain
{
    public interface IThread
    {
        bool Locked { get; set; }

        bool Running { get; set; }

        DateTime DateTime { set; }

        void ThreadStart();

        void ThreadUnlock();

        void ThreadSlice();

        Action ThreadStop { get; }

        void Output(string text);

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
