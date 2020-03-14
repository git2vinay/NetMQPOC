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
                    Console.WriteLine(" This is master changes that i need in feature branch");
                    Console.WriteLine(" BRanch changes ");
                    Console.WriteLine(" This is master changes that i need in feature branch +1 ");
                    Console.WriteLine(" This is master changes that i need in feature branch +2");
                    Console.WriteLine(" This is master changes that i need in feature branch +3");
                    Console.WriteLine(" This is master changes that i need in feature branch +4");

                    Console.WriteLine(" This is master changes that i need in feature branch +5");
                    Console.WriteLine(" This is master changes that i need in feature branch +4");


                    Console.WriteLine(" BRanch changes ");
                }
            }
            
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}