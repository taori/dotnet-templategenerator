using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json;

namespace Generator.Domain.Persistence
{
	public static class SerializationHelper
	{
		public static JsonSerializerSettings GetSettings()
		{
			var settings = new JsonSerializerSettings();
			settings.NullValueHandling = NullValueHandling.Ignore;
			settings.Formatting = Formatting.Indented;
			return settings;
		}
	}
}