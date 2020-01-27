using System;
using DryIoc;
using NetMQResponseServer.Services;

namespace NetMQResponseServer
{
    public class Bootstrapper : IDisposable
    {
        public static Container build()
        {
            var c=new Container();
            c.Register<IAccountService, AccountService>(Reuse.Singleton);
            return c;
        }
        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}