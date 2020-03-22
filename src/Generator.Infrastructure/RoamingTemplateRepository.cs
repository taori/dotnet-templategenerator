using System;
using System.Threading.Tasks;
using Generator.Domain.Configuration;
using Generator.Domain.Entities;
using Generator.Domain.Persistance;

namespace Generator.Infrastructure
{
	public class RoamingTemplateRepository : ITemplateRepository
	{
		private readonly Settings _settings;

		public RoamingTemplateRepository(Settings settings)
		{
			_settings = settings;
		}

		/// <inheritdoc />
		public Task<Template[]> GetTemplatesAsync()
		{
			throw new NotImplementedException();
		}
	}
}
