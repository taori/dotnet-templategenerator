﻿using System.Threading.Tasks;

namespace Generator.Domain.Features.Template
{
	public interface ITemplateManager
	{
		/// <summary>
		/// Creates a template container for the usage within this tool.
		/// </summary>
		/// <param name="identifier">identifier used to create/modify/delete a template.</param>
		/// <returns></returns>
		Task CreateAsync(string identifier, string workspace);

		Task RemoveAsync(string id, string workspace);
	}
}