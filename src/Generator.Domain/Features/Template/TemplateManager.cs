using System.Threading.Tasks;

namespace Generator.Domain.Features
{
	public class TemplateManager : ITemplateManager
	{
		public Task CreateAsync(string identifier, string workspace)
		{
			throw new System.NotImplementedException();
		}

		public Task RemoveAsync(string id, string workspace)
		{
			throw new System.NotImplementedException();
		}
	}
}