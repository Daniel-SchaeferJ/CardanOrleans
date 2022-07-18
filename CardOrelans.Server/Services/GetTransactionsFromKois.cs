using CardanoSharp.Koios.Sdk;
using CardanoSharp.Koios.Sdk.Contracts;
using Refit;

namespace CardanOrleans.Server.Services
{

    public interface IGetTransactionsFromKois
    {
        Task<Transaction> GetTransactions(string txHash);
    }
    public class GetTransactionsFromKois : IGetTransactionsFromKois
    {
        private readonly ITransactionClient  _transactionClient;

        public GetTransactionsFromKois()
        {
            _transactionClient = RestService.For<ITransactionClient>("https://api.koios.rest/api/v0");;
        }

        public async Task<Transaction> GetTransactions(string txHash)
        {
            var request = await _transactionClient.GetTransactionInformation(new GetTransactionRequest()
            {
                TxHashes = new List<string>() {txHash}
            });

            return request.Content.FirstOrDefault();
        }
    }
}
