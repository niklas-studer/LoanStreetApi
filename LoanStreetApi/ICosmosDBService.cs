namespace LoanStreetApi
{
    public interface ICosmosDBService
    {
        Task<Loan> GetAsync(string id);
        Task AddAsync(Loan item);
        Task UpdateAsync(string id, Loan item);
    }
}
