using CardanOrleans.Server.Orleans;
using Microsoft.AspNetCore.Mvc;
using Orleans;

namespace CardanOrleans.Server.Controllers
{
    [ApiController]
    [Route("transactions")]
    public class TransactionsHandler : ControllerBase
    {
        private readonly IClusterClient _clusterClient;
        private readonly ClusterClientHostedService _clusterClientHostedService;

        public TransactionsHandler(IClusterClient clusterClient, ClusterClientHostedService clusterClientHostedService)
        {
            _clusterClient = clusterClient;
            _clusterClientHostedService = clusterClientHostedService;
        }

        [HttpGet("get-transaction")]
        public async Task<IActionResult> Index(string txHash, CancellationToken token)
        {
            return Ok(await _clusterClient.GetGrain<ITransactionGrain>("yup").GetTransaction(txHash));
        }

        [HttpPost("update-transaction")]
        public async Task<IActionResult> UpdateTransaction(string txHash, CancellationToken token)
        {
            return Ok(await _clusterClient.GetGrain<ITransactionGrain>("yup").UpdateTransaction((uint)22222));
        }
    }
}
