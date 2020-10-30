using Thread.Runner.Domain;

namespace Thread.Runner
{
    public static class Handlers
    {
        public static void Start(IThread thread)
        {
            if (thread.Running)
                return;

            thread.Locked = true;

            thread.Running = true;

            new System.Threading.Thread(thread.Run).Start();
        }

        public static void Stop(IThread thread)
        {
            if (!thread.Running)
                return;

            thread.Locked = false;
        }
    }
}
