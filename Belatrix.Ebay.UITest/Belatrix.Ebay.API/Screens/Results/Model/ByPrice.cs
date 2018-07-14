
using System;

namespace Belatrix.Ebay.API.Screens.Results.Model
{
	internal class ByPrice : Attribute
	{
		/// <summary>
		/// Construye una nueva instancia
		/// </summary>
		/// <param name="ascendantByPrice">Ordena por precio</param>
		public ByPrice(string sorbyPrice)
		{
			SortByPrice = sorbyPrice;
		}

		/// <summary>
		/// Obtiene o establece el valor ascendente por precio
		/// </summary>
		public string SortByPrice { get; set; }
	}
}
