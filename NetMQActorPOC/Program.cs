using System;
using NetMQActorPOC;

namespace NetMQActorPOC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // CommandActioner uses an NetMq.Actor internally
            var accountActioner = new AccountActioner();
            var account = new Account(1, "Doron Somech", "112233", 0);
             accountActioner.Start();
             
            Console.WriteLine("Sending account to AccountActioner/Actor");
            accountActioner.SendPayload(account,
                new AccountAction(TransactionType.Credit, 15));
            account = accountActioner.GetPayLoad();
            PrintAccount(account);
            accountActioner.Stop();
            Console.WriteLine();
            Console.WriteLine("Sending account to AccountActioner/Actor");
            accountActioner.SendPayload(account,
                new AccountAction(TransactionType.Debit, 15));
            //account = accountActioner.GetPayLoad();
            PrintAccount(account);
            Console.ReadLine();
        }
        static void PrintAccount(Account account)
        {
            Console.WriteLine("Account now");
            Console.WriteLine(account);
            Console.WriteLine();
        }
    }
}