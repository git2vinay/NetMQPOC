using NetMQActorPOC;

namespace NetMQResponseServer.Services
{
    public class AccountService : IAccountService
    {
        public AccountService()
        {
        }

        public Account GetAccount()
        {
            var account = new Account(1, "Doron Somech", "112233", 0);
            return account;
        }
    }
}