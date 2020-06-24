using System.Threading.Tasks;

namespace Generator.Domain.Features
{
	public interface IWorkspaceManager
	{
		Task CreateAsync(string id);
	}
}