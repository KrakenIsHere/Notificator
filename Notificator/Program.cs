using System;
using System.Threading;
using System.Timers;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Notificator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How often do you wish to be reminded (minutes): ");
            var interval = int.Parse(Console.ReadLine());

            var thread = new Thread(() =>
            {
                var timer = new System.Timers.Timer();

                Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
                timer.Elapsed += Timer_Elapsed;
                timer.Interval = (interval * 60 * 1000);
                timer.Start();
            });

            thread.Start();

            Forever();
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Notifying");
            new ToastContentBuilder()
                .AddText("REMEMBER!!!")
                .AddText("Check your posture")
                .Show();
            Console.WriteLine("Notified");
        }

        static void Forever()
        {
            string exitChar = "";

            while (exitChar != "e")
            {
                Console.Read();
            }
        }
    }
}
