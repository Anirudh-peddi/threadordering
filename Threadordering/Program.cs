using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Thread_Ordering
{
    class Mythreads
    {
        Semaphore sem = new Semaphore(0, 1);
        public void Thread1()
        {
            Console.WriteLine("Thread1 executes before thread2");
            sem.Release();
        }
        public void Thread2()
        {
            sem.WaitOne();
            //CS
            Console.WriteLine("thread2 executes after thread1");
            sem.Release();
        }
}

    class Program
    {
        static void Main(string[] args)
        {
            Mythreads myThread = new Mythreads();
            Thread t1 = new Thread(myThread.Thread1);
            Thread t2 = new Thread(myThread.Thread2);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
            Console.WriteLine("main thread is exiting");
            Console.ReadLine();
        }
    }
}
