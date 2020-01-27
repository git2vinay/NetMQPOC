using System;
using System.Threading;
using NetMQ;
using NetMQ.Sockets;
using NetMQActorPOC;
using Newtonsoft.Json;

namespace NetMQActorPOC
{
public class AccountActioner
{
    public class ShimHandler : IShimHandler
    {
        private PairSocket shim;
        private NetMQPoller poller;
        public void Initialise(object state)
        {
        }
        public void Run(PairSocket shim)
        {
            this.shim = shim;
            shim.ReceiveReady += OnShimReady;
            shim.SignalOK();
            poller = new NetMQPoller { shim };
            poller.Run();
        }
        private void OnShimReady(object sender, NetMQSocketEventArgs e)
        {
            string command = e.Socket.ReceiveFrameString();
            switch (command)
            {
                case NetMQActor.EndShimMessage:
                    Console.WriteLine("Actor received EndShimMessage");
                    poller.Stop();
                    break;
                case "AmmendAccount":
                    Console.WriteLine("Actor received AmmendAccount message");
                    string accountJson = e.Socket.ReceiveFrameString();
                    
                    Console.WriteLine("***************************************************");
                    Console.WriteLine();
                    
                    Console.WriteLine(accountJson);
                    
                    Console.WriteLine();
                    Console.WriteLine("***************************************************");
                    
                    Account account
                        = JsonConvert.DeserializeObject<Account>(accountJson);
                    
                    Console.WriteLine("***************************************************");
                    Console.WriteLine();
                    
                    Console.WriteLine(account);
                    
                    Console.WriteLine();
                    Console.WriteLine("***************************************************");
                    
                    
                    string accountActionJson = e.Socket.ReceiveFrameString();
                    AccountAction accountAction
                        = JsonConvert.DeserializeObject<AccountAction>(
                            accountActionJson);
                    
                    Console.WriteLine("***************************************************");
                    Console.WriteLine();
                    
                    Console.WriteLine(accountActionJson);
                    
                    Console.WriteLine();
                    Console.WriteLine("***************************************************");
                    
                    
                    Console.WriteLine("Incoming Account details are");
                    Console.WriteLine(account);
                    AmmendAccount(account, accountAction);
                    shim.SendFrame(JsonConvert.SerializeObject(account));
                    break;
            }
        }
        private void AmmendAccount(Account account, AccountAction accountAction)
        {
            switch (accountAction.TransactionType)
            {
                case TransactionType.Credit:
                    account.Balance += accountAction.Amount;
                    break;
                case TransactionType.Debit:
                    account.Balance -= accountAction.Amount;
                    break;
            }
        }
    }
    private NetMQActor actor;
    public void Start()
    {
        if (actor != null)
            return;
        actor = NetMQActor.Create(new ShimHandler());
    }
    public void Stop()
    {
        if (actor != null)
        {
            actor.Dispose();
            actor = null;
        }
    }
    public void SendPayload(Account account, AccountAction accountAction)
    {
        if (actor == null)
            return;
        Console.WriteLine("About to send person to Actor");
        var message = new NetMQMessage();
        message.Append("AmmendAccount");
        message.Append(JsonConvert.SerializeObject(account));
        message.Append(JsonConvert.SerializeObject(accountAction));
        actor.SendMultipartMessage(message);
        Thread.Sleep(1000);
        Console.WriteLine(" Woke up from the sleep ");

    }
    public Account GetPayLoad()
    {
        Console.WriteLine(" Testing asynch aspect of the Actor");
        return JsonConvert.DeserializeObject<Account>(actor.ReceiveFrameString());
    }
}



}