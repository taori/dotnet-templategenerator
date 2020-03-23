namespace Generator.Domain.Entities
{
	public enum SymbolType
	{
		/// <summary>
		/// Defines a symbol that has its value provided by the host
		/// </summary>
		Bind,

		/// <summary>
		/// Defines the high level configuration of symbol
		/// </summary>
		Derived,

		/// <summary>
		/// Defines the high level configuration of symbol
		/// </summary>
		Generated,

		/// <summary>
		/// Defines the high level configuration of symbol
		/// </summary>
		Parameter,

		/// <summary>
		/// Defines the high level configuration of symbol
		/// </summary>
		Computed
	}
}