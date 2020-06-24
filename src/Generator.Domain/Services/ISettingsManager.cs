using System.Threading.Tasks;
using Generator.Domain.Configuration;

namespace Generator.Domain.Services
{
    public interface ISettingsManager
    {
        Task SaveAsync(Settings settings);
        Task<Settings> LoadAsync();
    }
}