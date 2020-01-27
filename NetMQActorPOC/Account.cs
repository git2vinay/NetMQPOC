namespace NetMQActorPOC
{
    public class Account
    {
        public Account(int id, string name, string sortCode, decimal balance)
        {
            Id = id;
            Name = name;
            SortCode = sortCode;
            Balance = balance;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string SortCode { get; set; }
        public decimal Balance { get; set; }
        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, SortCode: {2}, Balance: {3}",Id, Name, SortCode, Balance);
        }
    }
}