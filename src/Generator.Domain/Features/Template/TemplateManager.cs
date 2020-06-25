using System.Collections.Generic;
using System.IO.Abstractions;
using System.Threading.Tasks;
using Generator.Domain.Entities;
using Generator.Domain.Features.Workspace;

namespace Generator.Domain.Features.Template
{
	public class TemplateManager : ITemplateManager
	{
		private readonly IWorkspaceManager _workspaceManager;

		public TemplateManager(IWorkspaceManager workspaceManager)
		{
			_workspaceManager = workspaceManager;
		}
		
		public Task<TemplateContainer> CreateAsync(string id, string workspace)
		{
			throw new System.NotImplementedException();
		}

		public Task RemoveAsync(string id, string workspace)
		{
			throw new System.NotImplementedException();
		}

		public Task<IList<TemplateContainer>> GetAllByWorkspace(string workspace)
		{
			throw new System.NotImplementedException();
		}

		public Task<TemplateContainer> GetById(string workspace, string id)
		{
			throw new System.NotImplementedException();
		}
	}
}