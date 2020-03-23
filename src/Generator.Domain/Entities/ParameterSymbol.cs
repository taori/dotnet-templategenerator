namespace Generator.Domain.Entities
{
	public class ParameterSymbol  : BaseSymbol
	{
		/// <inheritdoc />
		protected override SymbolType GetDefaultType()
		{
			return SymbolType.Parameter;
		}
	}
}