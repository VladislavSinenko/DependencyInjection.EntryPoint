using System.Threading.Tasks;

namespace DependencyInjection.EntryPoint
{
    public interface IEntryPoint
    {
        Task RunAsync();
    }
}
