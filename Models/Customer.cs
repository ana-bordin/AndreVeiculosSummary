namespace Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Address Address { get; set; }
        public Bank Bank { get; set; }

    }
}
