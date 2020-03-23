using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Generator.Domain.Entities
{
	public abstract class BaseSymbol
	{
		/// <summary>
		/// choice / bool / float / int / hex / text
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public SymbolDataType DataType { get; set; }

		/// <summary>
		/// Symbol type - e.g. parameter, generated ...
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		public SymbolType Type
		{
			get { return GetDefaultType(); }
			set { }
		}

		/// <summary>
		/// The text to replace with the value of this symbol
		/// </summary>
		public string Replaces { get; set; }
		
		public ChoiceValue[] Choices { get; set; }

		public string DefaultValue { get; set; }

		public string Description { get; set; }

		protected abstract SymbolType GetDefaultType();
	}
}