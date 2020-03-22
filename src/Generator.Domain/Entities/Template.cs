using System;
using System.Collections.Generic;

namespace Generator.Domain.Entities
{
	// http://json.schemastore.org/template
	public class Template
	{
		/// <summary>
		/// http://json.schemastore.org/template
		/// </summary>
		public string Schema { get; set; } = "http://json.schemastore.org/template";

		/// <summary>
		/// Author of template
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// The name to use during creation if no name has been specified and no other opinionation about naming has been provided from the host
		/// </summary>
		public string DefaultName { get; set; }

		/// <summary>
		/// name used to generate the template
		/// </summary>
		public string ShortName { get; set; }

		/// <summary>
		/// Long name used to generate the template
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Identity of the template
		/// </summary>
		public string Identity { get; set; }

		/// <summary>
		/// Classifications, such as web, console, etc.
		/// </summary>
		public string[] Classifications { get; set; }

		/// <summary>
		/// Description of the template
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// The ID of the group this template belongs to. When combined with the \"tags\" section, this allows multiple templates to be displayed as one, with the the decision for which one to use being presented as a choice in each one of the pivot categories (keys).
		/// </summary>
		public string GroupIdentity { get; set; }

		/// <summary>
		/// An URL for a document indicating any libraries used by the template that are not owned/provided by the template author
		/// </summary>
		public string ThirdPartyNotices { get; set; }

		/// <summary>
		/// Parameter passed through -n when using the template
		/// </summary>
		public string SourceName { get; set; }

		/// <summary>
		/// Indicates whether to create a directory for the template if name is specified but an output directory is not set (instead of creating the content directly in the current directory)
		/// </summary>
		public bool PreferNameDirectory { get; set; } = true;
		
		/// <summary>
		/// A list of guids which appear in the template source and should be replaced in the template output. For each guid listed, a replacement guid is generated, and replaces all occurrences of the source guid in the output.
		/// </summary>
		public Guid[] Guids { get; set; }

		/// <summary>
		/// Common information about templates, these are effectively interchangeable with choice type parameter symbols
		/// </summary>
		public Tags Tags { get; set; } = new Tags();

		/// <summary>
		/// The symbols section defines variables and their values, the values may be the defined in terms of other symbols. When a defined symbol name is encountered anywhere in the template definition, it is replaced by the value defined in this configuration. The symbols configuration is a collection of key-value pairs. The keys are the symbol names, and the value contains key-value-pair configuration information on how to assign the symbol a value.
		/// </summary>
		public Dictionary<string, Symbol> Symbols { get; set; } = new Dictionary<string, Symbol>();

		/// <summary>
		/// A filename that will be completely ignored except to indicate that its containing directory should be copied. This allows creation of an empty directory in the created template, by having a corresponding source directory containing just the placeholder file. Completely empty directories are ignored.
		/// </summary>
		public string PlaceholderFileName { get; set; } = "-.-";
	}
}
