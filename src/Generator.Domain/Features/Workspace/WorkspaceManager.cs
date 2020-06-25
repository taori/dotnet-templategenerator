﻿using System;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Generator.Domain.FileSystem;
using Generator.Domain.Resources;
using Generator.Domain.Utility;
using NLog;

namespace Generator.Domain.Features.Workspace
{
	public class WorkspaceManager : IWorkspaceManager
	{
		private static readonly ILogger Log = LogManager.GetLogger("WorkspaceCreation");
		
		private readonly IRoamingPathService _roamingPathService;
		private readonly IFileSystem _fileSystem;

		public WorkspaceManager(IRoamingPathService roamingPathService, IFileSystem fileSystem)
		{
			_roamingPathService = roamingPathService ?? throw new ArgumentNullException(nameof(roamingPathService));
			_fileSystem = fileSystem ?? throw new ArgumentNullException(nameof(fileSystem));
		}

		public Task<IWorkspace> CreateAsync(string id)
		{
			Log.Debug("Creating workspace");
			var path = _roamingPathService.GetPath(Constants.Paths.Workspace, id);
			if (_fileSystem.Directory.Exists(path))
				throw new WellKnownException(Constants.WellKnownErrorCodes.WorkspaceAlreadyExists, $"Workspace {id} already exists.");
			
			_roamingPathService.EnsureDirectoryExists(Constants.Paths.Workspace, id);
			
			return Task.FromResult(new Workspace(path) as IWorkspace);
		}

		public Task<IWorkspace> GetAsync(string id)
		{
			Log.Debug("Retrieving workspace {Id}", id);
			var path = _roamingPathService.GetPath(Constants.Paths.Workspace, id);
			if (!_fileSystem.Directory.Exists(path))
				throw new WellKnownException(Constants.WellKnownErrorCodes.WorkspaceDoesNotExist, $"Workspace {id} does not exist.");
			
			return Task.FromResult(new Workspace(path) as IWorkspace);
		}

		public Task<bool> RemoveAsync(string id)
		{
			try
			{
				Log.Debug("Retrieving workspace {Id}", id);
				var path = _roamingPathService.GetPath(Constants.Paths.Workspace, id);
				if (!_fileSystem.Directory.Exists(path))
					throw new WellKnownException(Constants.WellKnownErrorCodes.WorkspaceDoesNotExist, $"Workspace {id} does not exist.");

				_fileSystem.Directory.Delete(path);
				return Task.FromResult(true);
			}
			catch (Exception e)
			{
				Log.Error(e, "Failed to delete workspace {Id}", id);
				return Task.FromResult(false);
			}
		}

		public bool Exists(string id)
		{
			var path = _roamingPathService.GetPath(Constants.Paths.Workspace, id);
			return _fileSystem.Directory.Exists(path);
		}
	}
}