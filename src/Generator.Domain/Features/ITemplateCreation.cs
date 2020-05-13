using System.Threading.Tasks;
using Generator.Domain.Entities;

namespace Generator.Domain.Features
{
	public interface ITemplateCreation
	{
		/// <summary>
		/// Creates a template container for the usage within this tool.
		/// </summary>
		/// <param name="identifier">identifier used to create/modify/delete a template.</param>
		/// <returns></returns>
		Task CreateAsync(string identifier);
	}
}