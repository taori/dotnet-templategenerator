using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Generator.Domain.Configuration;
using Generator.Domain.Entities;
using Generator.Domain.Persistence;

namespace Generator.Infrastructure
{
	public class RoamingTemplateRepository : ITemplateRepository
	{
		private readonly Settings _settings;

		public RoamingTemplateRepository(Settings settings)
		{
			_settings = settings;
		}

		public Task<TemplateContainer[]> GetTemplatesAsync()
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public Task SaveAsync(IEnumerable<TemplateContainer> containers)
		{
			throw new NotImplementedException();
		}
	}
}
