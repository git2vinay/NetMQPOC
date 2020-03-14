using System;
using NetMQ;
using NetMQ.Sockets;
using NetMQActorPOC;
using Newtonsoft.Json;

namespace NetMQRequestClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var requestSocket = new RequestSocket("tcp://localhost:5555"))
            {
                Console.WriteLine("requestSocket : Sending 'Hello'"); 
                requestSocket.SendFrame("Hello");
                var message = requestSocket.ReceiveFrameString();
                Account account
                    = JsonConvert.DeserializeObject<Account>(message);
                Console.WriteLine("requestSocket : Received '{0}'", account);
                Console.ReadLine();
                Console.WriteLine(" Testing of the rebasing in the ");
            }

        }
    }
}