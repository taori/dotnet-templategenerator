using System.Collections.Generic;
using System.Threading.Tasks;
using Generator.Domain.Entities;

namespace Generator.Domain.Persistence
{
	public interface ITemplateRepository
	{
		Task<TemplateContainer[]> GetTemplatesAsync(string workspace);
		Task SaveAsync(string workspace, IEnumerable<TemplateContainer> containers);
	}
}