using Belatrix.Ebay.API.Screens.SearchAdvanced.AdvancedSearchClasses;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;

namespace Belatrix.Ebay.API.Screens.Home.HomeClasses
{
	/// <summary>
	/// Representa las acciones de la pantalla "Inicio"
	/// </summary>
	public partial class Home
    {
		/// <summary>
		/// Selecciona la opción de búsqueda avanzada
		/// </summary>
		/// <returns><see cref="AdvancedSearch"/></returns>
		public AdvancedSearch SelectAdvancedSearch()
		{
			Mouse.Click(UIHomePage.Body.AdvancedSearch);
			return new AdvancedSearch();
		}
    }
}
