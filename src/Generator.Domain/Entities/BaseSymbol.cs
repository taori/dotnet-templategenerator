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
		[JsonProperty("dataType")]
		public SymbolDataType DataType { get; set; }

		/// <summary>
		/// Symbol type - e.g. parameter, generated ...
		/// </summary>
		[JsonConverter(typeof(StringEnumConverter))]
		[JsonProperty("type")]
		public SymbolType Type
		{
			get { return GetDefaultType(); }
			set { }
		}

		/// <summary>
		/// The text to replace with the value of this symbol
		/// </summary>
		[JsonProperty("replaces")]
		public string? Replaces { get; set; }
		
		[JsonProperty("choices")]
		public ChoiceValue[] Choices { get; set; }

		[JsonProperty("defaultValue")]
		public string? DefaultValue { get; set; }

		[JsonProperty("description")]
		public string? Description { get; set; }

		protected abstract SymbolType GetDefaultType();
	}
}