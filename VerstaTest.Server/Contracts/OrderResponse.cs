namespace VerstaTest.Server.Contracts
{
    public record OrderResponse(
         Guid Id,
            string RecipientCity,
            string RecipientAddress,
            string AddresserCity,
            string AddresserAddress,
            float CargoWeight,
            DateTime RecieveDate
        );


}
