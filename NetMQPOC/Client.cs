using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;

namespace NetMQPOC
{
    public class Client : IDisposable
    
    {
        public void setupClient()
        {
            using (var client = new RequestSocket())
            {
                client.Connect("tcp://localhost:5555");
                for (int i = 0; i < 10; i++)
                {
                    client.SendFrame("Hello");
                    var message = client.ReceiveFrameString();
                    Console.WriteLine(" Received Messages {0} {1}",message,"got it");
                    Thread.Sleep(1000);
                }
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}