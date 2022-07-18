using CardanOrleans.Server.Orleans;
using CardanOrleans.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace CardanOrleans.Server.Controllers
{
    [ApiController]
    [Route("transactions")]
    public class TransactionsHandler : ControllerBase
    {
        private readonly IClusterClient _clusterClient;
        private readonly IGetTransactionsFromKois _getTransactionsFromKois;

        public TransactionsHandler(IClusterClient clusterClient, IGetTransactionsFromKois getTransactionsFromKois)
        {
            _clusterClient = clusterClient;
            _getTransactionsFromKois = getTransactionsFromKois;
        }

        [HttpGet("get-transaction")]
        public async Task<IActionResult> Index(string txHash, CancellationToken token)
        {
            var transaction = await _clusterClient.GetGrain<ITransactionGrain>(txHash).GetTransaction();

            if (transaction.Epock is 0)
            {
                transaction = await _getTransactionsFromKois.GetTransactions(txHash);

                await _clusterClient.GetGrain<ITransactionGrain>(txHash).UpdateTransaction(transaction);
            }
            return Ok(transaction);
        }
    }
}
