using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threadings
{
    class MonitorHandleEventInterlocked
    {
        private static int numOps;
        private static AutoResetEvent opsAreDone = new AutoResetEvent(false);
        private static SyncResource SyncRes = new SyncResource();
        private static UnSyncResource UnSyncRes = new UnSyncResource();

        public static void Run()
        {
            // Set the number of synchronized calls.
            numOps = 5;

            var count = numOps;
            for (int ctr = 0; ctr < count; ctr++)
                ThreadPool.QueueUserWorkItem(o =>
                {
                    // Call the internal synchronized method.
                    SyncRes.Access();

                    // Ensure that only one thread can decrement the counter at a time.
                    if (Interlocked.Decrement(ref numOps) == 0)
                        // Announce to Main that in fact all thread calls are done.
                        opsAreDone.Set();
                });

            // Wait until this WaitHandle is signaled.
            opsAreDone.WaitOne();
            Console.WriteLine("\t\nAll synchronized operations have completed.\n");

            // Reset the count for unsynchronized calls.
            numOps = 5;
            count = numOps;
            for (int ctr = 0; ctr < count; ctr++)
                ThreadPool.QueueUserWorkItem(o =>
                {
                    // Call the unsynchronized method.
                    UnSyncRes.Access();

                    // Ensure that only one thread can decrement the counter at a time.
                    if (Interlocked.Decrement(ref numOps) == 0)
                        // Announce to Main that in fact all thread calls are done.
                        opsAreDone.Set();
                });

            // Wait until this WaitHandle is signaled.
            opsAreDone.WaitOne();
            Console.WriteLine("\t\nAll unsynchronized thread operations have completed.\n");
        }
    }

    internal class SyncResource
    {
        public void Access()
        {
            lock(this)
            {
                Console.WriteLine($"Staring synchronized resource access on thread #{Thread.CurrentThread.ManagedThreadId}");

                if (Thread.CurrentThread.ManagedThreadId % 2 == 0)
                    Thread.Sleep(2000);
                Thread.Sleep(200);

                Console.WriteLine($"Stopping synchronized resource access on thread #{Thread.CurrentThread.ManagedThreadId}");
            }
        }
    }

    internal class UnSyncResource
    {
        public void Access()
        {
            Console.WriteLine($"Staring UnsyncResource resource access on thread #{Thread.CurrentThread.ManagedThreadId}");

            if (Thread.CurrentThread.ManagedThreadId % 2 == 0)
                Thread.Sleep(2000);
            Thread.Sleep(200);

            Console.WriteLine($"Stopping UnsyncResource resource access on thread #{Thread.CurrentThread.ManagedThreadId}");
        }
    }

}
