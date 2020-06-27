using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Generator.Domain.Entities;
using Generator.Domain.Extensions;
using Generator.Domain.Features.Workspace;
using Generator.Domain.Resources;
using Generator.Domain.Utility;
using Newtonsoft.Json;

namespace Generator.Domain.Features.Template
{
	public class TemplateManager : ITemplateManager
	{
		private readonly IWorkspaceManager _workspaceManager;
		private readonly IFileSystem _fileSystem;

		public TemplateManager(IWorkspaceManager workspaceManager, IFileSystem fileSystem)
		{
			_workspaceManager = workspaceManager;
			_fileSystem = fileSystem;
		}
		
		public async Task<TemplateContainer> CreateAsync(string id, string workspaceId)
		{
			var workspace = _workspaceManager.Exists(workspaceId)
				? await _workspaceManager.GetAsync(workspaceId)
				: await _workspaceManager.CreateAsync(workspaceId);
			
			var path = Path.Combine(workspace.Directory, Constants.Paths.Templates, $"{id}.json");
			_fileSystem.File.EnsureDirectoryExists(path);
			
			if(_fileSystem.File.Exists(path))
				throw new TemplateAlreadyExistsException(id);
			
			using var stream = _fileSystem.FileStream.Create(path, FileMode.Create);
			using var streamWriter = new StreamWriter(stream);
			var container = new TemplateContainer();
			await streamWriter.WriteAsync(JsonConvert.SerializeObject(container));
			return container;
		}

		public async Task RemoveAsync(string id, string workspaceId)
		{
			if(!_workspaceManager.Exists(workspaceId))
				throw new WorkspaceNotFoundException(workspaceId);
			
			var workspace = await _workspaceManager.GetAsync(workspaceId);
			var path = Path.Combine(workspace.Directory, Constants.Paths.Templates, $"{id}.json");
			if(!_fileSystem.File.Exists(path))
				throw new TemplateNotFoundException(id);
			
			_fileSystem.File.Delete(path);
		}

		public async Task<IList<TemplateContainer>> GetAllByWorkspaceAsync(string workspaceId)
		{
			if(!_workspaceManager.Exists(workspaceId))
				throw new WorkspaceNotFoundException(workspaceId);
			
			var workspace = await _workspaceManager.GetAsync(workspaceId);
			var path = Path.Combine(workspace.Directory, Constants.Paths.Templates);
			var files = _fileSystem.Directory.EnumerateFiles(path, "*.json", SearchOption.TopDirectoryOnly);

			return await files.SelectAsync(async(d) => await DeserializeAsync(d)).ToListAsync();
		}

		private async Task<TemplateContainer> DeserializeAsync(string path)
		{
			using var stream = _fileSystem.FileStream.Create(path, FileMode.Open);
			using var streamReader = new StreamReader(stream);
			return JsonConvert.DeserializeObject<TemplateContainer>(await streamReader.ReadToEndAsync());
		}

		public async Task<TemplateContainer> GetByIdAsync(string workspaceId, string id)
		{
			if(!_workspaceManager.Exists(workspaceId))
				throw new WorkspaceNotFoundException(workspaceId);
			
			var workspace = await _workspaceManager.GetAsync(workspaceId);
			var path = Path.Combine(workspace.Directory, Constants.Paths.Templates, $"{id}.json");
			if(!_fileSystem.File.Exists(path))
				throw new TemplateNotFoundException(id);
			
			return await DeserializeAsync(path);
		}
	}
}