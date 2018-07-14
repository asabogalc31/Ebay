using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.Ebay.API.Screens.Results.Model
{
	/// <summary>
	/// Representa las opciones de ordenamiento de resultados
	/// </summary>
	internal enum EnumSortResults
	{
		[ByPrice("Precio + Envío: más bajo primero")]
		ByAscendantPrice,

		[ByPrice("Precio + Envío: más alto primero")]
		ByDescendantPrice
	}
}
