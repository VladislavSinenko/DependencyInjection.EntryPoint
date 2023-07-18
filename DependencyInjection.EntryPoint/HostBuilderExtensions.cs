using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DependencyInjection.EntryPoint
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder UseEntryPoint<TEntryPiont>(this IHostBuilder builder) where TEntryPiont : class, IEntryPoint
        {
            builder.ConfigureServices(s => s.AddSingleton<TEntryPiont>());
            return new EntryPointHostBuilder<TEntryPiont>(builder);
        }
    }
}
