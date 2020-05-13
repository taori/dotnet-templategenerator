namespace Generator.Domain.Entities
{
	public class TemplateContainer
	{
		/// <summary>
		/// Id used to identify a template within this tool
		/// </summary>
		public string Id { get; set; }

		/// <summary>
		/// Contents of a template
		/// </summary>
		public Template Temlate { get; set; }
	}
}