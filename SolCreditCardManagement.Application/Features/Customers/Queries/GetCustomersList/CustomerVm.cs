namespace SolCreditCardManagement.Application.Features.Customers.Queries.GetCustomersList
{
    public class CustomerVm
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
    }
}