using Orleans;

namespace CardOrelans.Server.Services
{

    public interface IGetTransactionsFromKoisGrain : IGrainWithGuidKey
    {
        Task GetTransactions();
    }
    public class GetTransactionsFromKoisGrain : Grain, IGetTransactionsFromKoisGrain
    {
        public Task GetTransactions()
        {
            throw new NotImplementedException();
        }
    }
}
