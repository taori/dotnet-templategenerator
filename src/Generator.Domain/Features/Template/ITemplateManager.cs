using System.Collections.Generic;
using System.Threading.Tasks;
using Generator.Domain.Entities;

namespace Generator.Domain.Features.Template
{
	public interface ITemplateManager
	{
		/// <summary>
		/// Creates a template container for the usage within this tool.
		/// </summary>
		/// <param name="id">identifier used to create/modify/delete a template.</param>
		/// <param name="workspace">containing workspace</param>
		/// <returns></returns>
		Task<TemplateContainer> CreateAsync(string id, string workspace);

		Task RemoveAsync(string id, string workspace);

		Task<IList<TemplateContainer>> GetAllByWorkspace(string workspace);
		
		Task<TemplateContainer> GetById(string workspace, string id);
	}
}