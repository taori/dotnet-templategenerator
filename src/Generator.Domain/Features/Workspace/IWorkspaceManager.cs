using System.Threading.Tasks;

namespace Generator.Domain.Features.Workspace
{
	public interface IWorkspaceManager
	{
		Task CreateAsync(string id);
	}
}