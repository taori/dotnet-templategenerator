using System;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Generator.Domain.FileSystem;
using Generator.Domain.Resources;
using Generator.Domain.Utility;
using NLog;

namespace Generator.Domain.Features
{
	public class WorkspaceManager : IWorkspaceManager
	{
		private static readonly NLog.ILogger Log = LogManager.GetLogger("WorkspaceCreation");
		
		private readonly IRoamingPathService _roamingPathService;
		private readonly IFileSystem _fileSystem;

		public WorkspaceManager(IRoamingPathService roamingPathService, IFileSystem fileSystem)
		{
			_roamingPathService = roamingPathService ?? throw new ArgumentNullException(nameof(roamingPathService));
			_fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
		}
		
		public Task CreateAsync(string id)
		{
			Log.Debug("Creating workspace");
			var path = _roamingPathService.GetPath(Constants.Paths.Workspace, id);
			if (_fileSystem.Directory.Exists(path))
				throw new WellKnownException(Constants.WellKnownErrorCodes.WorkspaceAlreadyExists, $"Workspace {id} already exists.");
			
			_roamingPathService.EnsureDirectoryExists(Constants.Paths.Workspace, id);
			return Task.CompletedTask;
		}
	}
}