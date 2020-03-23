namespace Generator.Domain.Entities
{
	public class ComputedSymbol : BaseSymbol
	{
		/// <inheritdoc />
		protected override SymbolType GetDefaultType()
		{
			return SymbolType.Computed;
		}
	}
}