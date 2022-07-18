using CardanOrleans.Server.Services;
using CardanoSharp.Koios.Sdk;
using CardanoSharp.Koios.Sdk.Contracts;
using Orleans;
using Orleans.Concurrency;
using Orleans.Core;
using Orleans.Runtime;

namespace CardanOrleans.Server.Orleans
{
    public interface ITransactionGrain : IGrainWithStringKey
    {
        public Task<Transaction> GetTransaction();
        Task UpdateTransaction(Transaction transaction);
    }

    [StatelessWorker]
    public class TransactionGrain : Grain<Transaction>, ITransactionGrain
    {
        Task<Transaction> ITransactionGrain.GetTransaction() => Task.FromResult(this.State);
        public async Task UpdateTransaction(Transaction transaction)
        {
            this.State = transaction;
            await WriteStateAsync();
        }


    }
}