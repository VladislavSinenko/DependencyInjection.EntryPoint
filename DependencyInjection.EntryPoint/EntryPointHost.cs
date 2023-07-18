using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DependencyInjection.EntryPoint
{
    internal class EntryPointHost<TEntryPoint> : IHost where TEntryPoint : IEntryPoint
    {
        private IHost host;
        public EntryPointHost(IHost host) => this.host = host;
        public IServiceProvider Services => host.Services;
        public void Dispose() => host.Dispose();
        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            await host.StartAsync(cancellationToken);
            await Services.GetRequiredService<TEntryPoint>().RunAsync();
        }
        public Task StopAsync(CancellationToken cancellationToken = default) => host.StopAsync(cancellationToken);
    }
}
