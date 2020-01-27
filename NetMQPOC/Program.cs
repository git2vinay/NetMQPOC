namespace NetMQPOC
{
    internal class Program
    {
        public static void Main(string[] args)
        {
           
            
            using (var client = new Client())
            {
                client.setupClient();
            }
            
            
        }
    }
}