using System;
using System.Threading;
using DryIoc;
using NetMQ;
using NetMQ.Sockets;
using NetMQActorPOC;
using NetMQResponseServer.Services;
using Newtonsoft.Json;

namespace NetMQResponseServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Container dryIocContainer=Bootstrapper.build();
            using (var responseSocket = new ResponseSocket("@tcp://*:5555"))
            {
                var message = responseSocket.ReceiveFrameString();
                Console.WriteLine("responseSocket : Server Received '{0}'", message);
                Console.WriteLine("responseSocket Sending 'World'");
                Account account=dryIocContainer.Resolve<IAccountService>().GetAccount();
                responseSocket.SendFrame(JsonConvert.SerializeObject(account));
                Thread.Sleep(100000);
            };
        }
    }
}