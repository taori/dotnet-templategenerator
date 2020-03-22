namespace Generator.Domain.Entities
{
	public class Modifier
	{
		/// <summary>
		/// Boolean-evaluable condition to indicate if the sources configuration should be included or ignored. If the condition evaluates to true or is not provided, the sources config will be used for creating the template. If it evaluates to false, the sources config will be ignored.
		/// </summary>
		public string Condition { get; set; }

		/// <summary>
		/// The set of globbing patterns indicating the content that was included by sources.include that should not be processed
		/// </summary>
		public string[] Exclude { get; set; }

		/// <summary>
		/// The set of globbing patterns indicating the content to process in the path referred to by sources.source
		/// </summary>
		public string[] Include { get; set; }
	}
}