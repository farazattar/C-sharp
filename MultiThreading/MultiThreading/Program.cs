using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread mainThread = Thread.CurrentThread;
            mainThread.Name = "Main Thread";
            Console.WriteLine(mainThread.Name);
            Thread thread1 = new Thread(CountDown);
            Thread thread2 = new Thread(CountUp);
            thread1.Start();
            thread2.Start();
            //CountDown();
            //CountUp();
            Console.WriteLine(mainThread.Name + " is completed.");
            Console.ReadKey();
        }
        public static void CountDown()
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine("Timer #1 is" + i + "seconds.");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Timer #1 is completed.");
        }
        public static void CountUp()
        {
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine("Timer #2 is" + i + "seconds.");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Timer #2 is completed.");
        }
    }
}
