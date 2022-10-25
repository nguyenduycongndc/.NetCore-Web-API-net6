using ProjectTest.Services.Interface;
using ProjectTest.Tool.ServicesTool.IServicesTool;

namespace ProjectTest.Tool.ServicesTool
{
    public class Worker : IWorker
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<Worker> _logger;
        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }
        private int number = 0;
        public async Task DoWork(CancellationToken cancellationToken)
        {
            //var listData = new List<BuysModel>();

            //using (var scope = _serviceScopeFactory.CreateScope())
            //{
            //    var buysService = scope.ServiceProvider.GetService<IBuysService>();
            //    var buyNFT = scope.ServiceProvider.GetService<IBuyNFT>();

            //    if (buyNFT != null)
            //    {
            //        while (!cancellationToken.IsCancellationRequested)
            //        {
            //            if (buysService != null)
            //            {
            //                listData = buysService.GetAllListBuy();
            //            }
            //            var result = new InputBuyModel();
            //            if (listData.Count() != 0)
            //            {
            //                result = JsonConvert.DeserializeObject<InputBuyModel>(listData[0].RequestBody);
            //            }
            //            else
            //            {
            //                result = null;
            //            }
            //            var tetNFT = buyNFT.GetDataHero(result);
            //            await Task.Delay(1000 * 30);
            //        }
            //    }
            //}
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var sendMailService = scope.ServiceProvider.GetService<ISendMailService>();

                while (!cancellationToken.IsCancellationRequested)
                {
                    Interlocked.Increment(ref number);
                    _logger.LogInformation($"Test: {number}");
                    await Task.Delay(1000 * 3);
                }
            }
        }
    }
}
