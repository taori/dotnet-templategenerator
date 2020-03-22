namespace Generator.Domain.Entities
{
	public class SourceValue
	{
		/// <summary>
		/// A list of additional source information which gets added to the top-level source information, based on evaluation the corresponding source.modifiers.condition.
		/// </summary>
		public Modifier[] Modifiers { get; set; }

		/// <summary>
		/// The path in the template content (relative to the directory containing the .template.config folder) that should be processed
		/// </summary>
		public string Source { get; set; } = "./";

		/// <summary>
		/// The path (relative to the directory the user has specified) that content should be written to
		/// </summary>
		public string Target { get; set; } = "./";
	}
}