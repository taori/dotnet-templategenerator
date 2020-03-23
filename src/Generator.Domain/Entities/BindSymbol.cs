using System.Collections.Generic;

namespace Generator.Domain.Entities
{
	public class BindSymbol : BaseSymbol
	{
		/// <inheritdoc />
		protected override SymbolType GetDefaultType()
		{
			return SymbolType.Bind;
		}
	}
}