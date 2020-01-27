using NetMQPOC;

namespace NetMQServer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            using (var server = new Server())
            {
                server.setupServer();
                
                
            }
        }
    }
}