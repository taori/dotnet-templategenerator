namespace Generator.Domain.Entities
{
	public class BaseSymbol
	{

	}

	public class ChoiceSymbol : BaseSymbol
	{
		public string DataType { get; set; } = "choice";

		public ChoiceValue[] Choices { get; set; }

		public string DefaultValue { get; set; }
	}

	public class ChoiceValue
	{
		public string Choice { get; set; }

		public string Description { get; set; }
	}

	public class ReplacementSymbol : BaseSymbol
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