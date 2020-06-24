using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Generator.Domain.Configuration;
using Generator.Domain.Resources;
using Generator.Domain.Services;
using Newtonsoft.Json;

namespace Generator.Infrastructure
{
	public class SettingsManager : ISettingsManager
	{
		private readonly IRoamingPathService _roamingPathService;
		private readonly IFileSystem _fileSystem;

		public SettingsManager(IRoamingPathService roamingPathService, IFileSystem fileSystem)
		{
			_roamingPathService = roamingPathService;
			_fileSystem = fileSystem;
		}
		
		public async Task SaveAsync(Settings settings)
		{
			var path = _roamingPathService.GetPath(Constants.Paths.SettingsFile);
			_roamingPathService.EnsureDirectoryExists(Constants.Paths.SettingsFile);
			using var stream = _fileSystem.FileStream.Create(path, FileMode.Create);
			using var streamWriter = new StreamWriter(stream);
			var content = JsonConvert.SerializeObject(settings);
			await streamWriter.WriteAsync(content);
		}

		public async Task<Settings> LoadAsync()
		{
			var path = _roamingPathService.GetPath(Constants.Paths.SettingsFile);
			if(!_fileSystem.File.Exists(path))
				return new Settings();

			using var stream = _fileSystem.FileStream.Create(path, FileMode.Open);
			using var streamReader = new StreamReader(stream);
			var content = await streamReader.ReadToEndAsync();
			return JsonConvert.DeserializeObject<Settings>(content);
		}
	}
}