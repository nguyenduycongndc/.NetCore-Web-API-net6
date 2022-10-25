using ProjectTest.Tool.ServicesTool.IServicesTool;

namespace ProjectTest.Tool
{
    public class DerivedBackgroundPrinter : BackgroundService
    {
        private readonly IWorker _worker;
        public DerivedBackgroundPrinter(IWorker worker)
        {
            _worker = worker;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _worker.DoWork(stoppingToken);
        }
    }
}
