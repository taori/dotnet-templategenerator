using System.Threading.Tasks;

namespace Generator.Domain.Features
{
	public interface IWorkspaceCreation
	{
		Task CreateAsync(string id);
	}
}