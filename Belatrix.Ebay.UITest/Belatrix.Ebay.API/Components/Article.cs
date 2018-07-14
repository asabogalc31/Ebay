using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.Ebay.API.Components
{
	/// <summary>
	/// Representa la información de un artículo
	/// </summary>
	public class Article
	{
		/// <summary>
		/// Obtiene o establece la palabra clave del artículo
		/// </summary>
		public string KeyWord { get; set; }

		/// <summary>
		/// Obtiene o establece la categoría
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// Obtiene o establece el nombre
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Obtiene o establece el precio
		/// </summary>
		public string Price { get; set; }
	}
}
