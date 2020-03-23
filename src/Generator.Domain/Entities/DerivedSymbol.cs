namespace Generator.Domain.Entities
{
	public class DerivedSymbol  : BaseSymbol
	{
		/// <inheritdoc />
		protected override SymbolType GetDefaultType()
		{
			return SymbolType.Derived;
		}
	}
}