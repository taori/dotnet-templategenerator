using System.Collections.Generic;
using Newtonsoft.Json;

namespace Generator.Domain.Entities
{
	public class Modifier
	{
		private static readonly string[] DefaultExcludes = {
			"**/[Bb]in/**",
			"**/[Oo]bj/**",
			".template.config/**/*",
			"**/*.filelist",
			"**/*.user",
			"**/*.lock.json"
		};

		private static readonly string[] DefaultIncludes = {
			"**/*"
		};

		private static readonly string[] DefaultCopyOnly = {
			"**/node_modules/**/*"
		};

		/// <summary>
		/// Boolean-evaluable condition to indicate if the sources configuration should be included or ignored. If the condition evaluates to true or is not provided, the sources config will be used for creating the template. If it evaluates to false, the sources config will be ignored.
		/// </summary>
		public string Condition { get; set; }

		/// <summary>
		/// The set of globbing patterns indicating the content that was included by sources.include that should not be processed
		/// </summary>
		public string[] Exclude { get; set; } = DefaultExcludes;

		/// <summary>
		/// The set of globbing patterns indicating the content to process in the path referred to by sources.source
		/// </summary>
		public string[] Include { get; set; } = DefaultIncludes;

		/// <summary>
		/// The set of globbing patterns indicating the content that was included by sources.include, that hasn't been excluded by sources.exclude that should be placed in the user's directory without modification
		/// </summary>
		public string[] CopyOnly { get; set; } = DefaultCopyOnly;

		public Dictionary<string, string> Rename { get; set; } = new Dictionary<string, string>();
	}
}