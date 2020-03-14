using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;

namespace NetMQPOC
{
    public class Server : IDisposable
    {

        public void setupServer()
        {

            using (var server = new ResponseSocket())
            {
                server.Bind("tcp://*:5555");
                while (true)
                {
                    var message = server.ReceiveFrameString();
                    Console.WriteLine(" Message Received on Server {0}",message);
                    Thread.Sleep(200);
                    server.SendFrame("World");
                }
            }
            
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}