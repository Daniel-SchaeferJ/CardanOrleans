using CardanoSharp.Koios.Sdk.Contracts;
using Orleans;

namespace CardanOrleans.Server.Orleans
{
    public interface ITransactionGrain : IGrainWithStringKey
    {
        public Task<Transaction> GetTransaction(string txHash);
        Task<Transaction> UpdateTransaction(uint txSize);
    }

    public class TransactionGrain : Grain<Transaction>, ITransactionGrain
    {
        public async Task<Transaction> GetTransaction(string txHash)
        {
            var yeet = this.GetPrimaryKeyString();
            this.State.TxHash = txHash;
            await WriteStateAsync();
            return await Task.FromResult(this.State);
            
            
        }


        public async Task<Transaction> UpdateTransaction(uint txSize)
        {
            this.State.TxSize = txSize;
            await WriteStateAsync();
            return await Task.FromResult(this.State);


        }
    }
}
