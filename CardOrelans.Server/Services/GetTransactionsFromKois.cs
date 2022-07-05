using Orleans;

namespace CardOrelans.Server.Services
{

    public interface IGetTransactionsFromKois
    {
        Task GetTransactions();
    }
    public class GetTransactionsFromKois : IGetTransactionsFromKois
    {
        public Task GetTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
