using System.Threading.Tasks;

namespace Generator.Domain.Features
{
	public interface ITemplateRemoval
	{
		Task RemoveAsync(string id, string? workspace);
	}
}