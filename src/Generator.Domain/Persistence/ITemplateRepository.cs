using System.Collections.Generic;
using System.Threading.Tasks;
using Generator.Domain.Entities;

namespace Generator.Domain.Persistence
{
	public interface ITemplateRepository
	{
		Task<TemplateContainer[]> GetTemplatesAsync();
		Task SaveAsync(IEnumerable<TemplateContainer> containers);
	}
}