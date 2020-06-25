using System.Threading.Tasks;

namespace Generator.Domain.Features.Workspace
{
	public interface IWorkspaceManager
	{
		Task<IWorkspace> CreateAsync(string id);

		Task<IWorkspace> GetAsync(string id);

		Task<bool> RemoveAsync(string id);
		
		bool Exists(string id);
	}
}