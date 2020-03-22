namespace Generator.Domain.Entities
{
	public class Symbol
	{
		public string Replaces { get; set; }

		/// <summary>
		/// Symbol type - e.g. parameter 
		/// </summary>
		public string Type { get; set; }

		/// <summary>
		/// Replacement value
		/// </summary>
		public string DefaultValue { get; set; }
	}
}