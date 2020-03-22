using System.Threading.Tasks;
using Generator.Domain.Entities;

namespace Generator.Domain.Persistance
{
	public interface ITemplateRepository
	{
		Task<Template[]> GetTemplatesAsync();
	}
}