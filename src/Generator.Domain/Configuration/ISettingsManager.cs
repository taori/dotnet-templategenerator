using System.Threading.Tasks;

namespace Generator.Domain.Configuration
{
    public interface ISettingsManager
    {
        Task SaveAsync(Settings settings);
        Task<Settings> LoadAsync();
    }
}