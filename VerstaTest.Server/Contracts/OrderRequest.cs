namespace VerstaTest.Server.Contracts
{
    public record OrderRequest(
            string RecipientCity,
            string RecipientAddress,
            string AddresserCity,
            string AddresserAddress,
            float CargoWeight,
            DateTime RecieveDate
        );
}
