namespace VerstaTest.Server.Model
{
    public class Order
    {
        private Order(Guid id, string recipientCity, string recipientAddress, string addresserCity, string addresserAddress, float cargoWeight, DateTime recieveDate)
        {
            Id = id;
            RecipientCity = recipientCity;
            RecipientAddress = recipientAddress;
            AddresserCity = addresserCity;
            AddresserAddress = addresserAddress;
            CargoWeight = cargoWeight;
            ReceiveDate = recieveDate;
        }

        public Guid Id { get;}
        public string RecipientCity { get;} = string.Empty;
        public string RecipientAddress { get; } = string.Empty;
        public string AddresserCity { get; } = string.Empty;
        public string AddresserAddress { get; } = string.Empty;
        public float CargoWeight { get; }
        public DateTime ReceiveDate { get; }

        public static Order Create(Guid id, string recipientCity, string recipientAddress, string addresserCity, string addresserAddress, float cargoWeight, DateTime recieveDate)
        {
            Order order = new Order (id, recipientCity, recipientAddress, addresserCity, addresserAddress, cargoWeight, recieveDate);
            return order;
        }
    }
}
