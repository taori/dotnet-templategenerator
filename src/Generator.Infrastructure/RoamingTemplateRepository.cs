using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Generator.Domain.Configuration;
using Generator.Domain.Entities;
using Generator.Domain.FileSystem;
using Generator.Domain.Persistence;
using Generator.Domain.Resources;
using Newtonsoft.Json;

namespace Generator.Infrastructure
{
	public class RoamingTemplateRepository : ITemplateRepository
	{
		private readonly IRoamingPathService _roamingPathService;
		private readonly IFileSystem _fileSystem;

		public RoamingTemplateRepository(IRoamingPathService roamingPathService, IFileSystem fileSystem)
		{
			_roamingPathService = roamingPathService;
			_fileSystem = fileSystem;
		}

		public async Task<TemplateContainer[]> GetTemplatesAsync(string workspace)
		{
			var filePath = _roamingPathService.GetPath(Constants.Paths.Workspace, workspace, "templates.json");
			if (!_fileSystem.File.Exists(filePath))
				return Array.Empty<TemplateContainer>();

			using var stream = _fileSystem.FileStream.Create(filePath, FileMode.Open);
			using var reader = new StreamReader(stream);
			var content = await reader.ReadToEndAsync();
			
			return await Task.Run(() => JsonConvert.DeserializeObject<TemplateContainer[]>(content))
				.ConfigureAwait(false);
		}

		/// <inheritdoc />
		public async Task SaveAsync(string workspace, IEnumerable<TemplateContainer> containers)
		{
			var filePath = _roamingPathService.GetPath(Constants.Paths.Workspace, workspace, "templates.json");
			_roamingPathService.EnsureDirectoryExists(Constants.Paths.Workspace, workspace, "templates.json");
			using var stream = _fileSystem.FileStream.Create(filePath, FileMode.Create);
			using var streamWriter = new StreamWriter(stream);
			var serialized = JsonConvert.SerializeObject(containers);
			await streamWriter.WriteAsync(serialized);
		}
	}
}