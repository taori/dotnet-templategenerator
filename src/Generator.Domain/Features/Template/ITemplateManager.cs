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
		/// <param name="workspaceId">containing workspace</param>
		/// <returns></returns>
		Task<TemplateContainer> CreateAsync(string id, string workspaceId);

		Task RemoveAsync(string id, string workspaceId);

		Task<IList<TemplateContainer>> GetAllByWorkspaceAsync(string workspaceId);
		
		Task<TemplateContainer> GetByIdAsync(string workspaceId, string id);
	}
}