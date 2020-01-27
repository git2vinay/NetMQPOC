using System;
using System.Runtime.CompilerServices;
using NetMQ;
using NetMQ.Sockets;

namespace NetMQPubSub
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int MegaBit = 1024;
            const int MegaByte = 1024;
            using (var pub = new PublisherSocket())
            using (var sub1 = new SubscriberSocket())
            using (var sub2 = new SubscriberSocket())
            {
                pub.Options.MulticastHops = 2;
                pub.Options.MulticastRate = 40 * MegaBit; // 40 megabit
                pub.Options.MulticastRecoveryInterval = TimeSpan.FromMinutes(10);
                pub.Options.SendBuffer = MegaByte * 10; // 10 megabyte
                pub.Connect("pgm://224.0.0.1:5555");
                sub1.Options.ReceiveBuffer = MegaByte * 10;
                sub1.Bind("pgm://224.0.0.1:5555");
                sub1.Subscribe("");
                sub2.Bind("pgm://224.0.0.1:5555");
                sub2.Options.ReceiveBuffer = MegaByte * 10;
                sub2.Subscribe("");
                Console.WriteLine("Server sending 'Hi'");
                pub.SendFrame("Hi",false);
                bool more;
                Console.WriteLine("sub1 received = '{0}'", sub1.ReceiveFrameString(out more));
                Console.WriteLine("sub2 received = '{0}'", sub2.ReceiveFrameString(out more));
            }
            
        }
    }
}