namespace Generator.Domain.Entities
{
	public class GeneratedSymbol  : BaseSymbol
	{
		/// <inheritdoc />
		protected override SymbolType GetDefaultType()
		{
			return SymbolType.Generated;
		}
	}
}