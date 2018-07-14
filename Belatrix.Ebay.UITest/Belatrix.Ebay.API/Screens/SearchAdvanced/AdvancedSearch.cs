using Belatrix.Ebay.API.Components;
using Belatrix.Ebay.API.Screens.Results.ResultsSearchClasses;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System.Linq;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;

namespace Belatrix.Ebay.API.Screens.SearchAdvanced.AdvancedSearchClasses
{
	/// <summary>
	/// Representa las acciones en la pantalla "Búsqueda avanzada"
	/// </summary>
	public partial class AdvancedSearch
	{
		/// <summary>
		/// Realiza la búsqueda avanazada de un artículo
		/// </summary>
		/// <param name="article"><see cref="Article"/></param>
		/// <returns><see cref="ResultsSearch"/></returns>
		public ResultsSearch SearchArticle(Article article)
		{
			// Ingresa la palabra clave
			Keyboard.SendKeys(UISearchAdvancedPage.Body.KeyWordArticle, article.KeyWord);

			// Selecciona la categoría
			Mouse.Click(UISearchAdvancedPage.Body.Category);
			HtmlControl bodyElement = new HtmlControl(UISearchAdvancedPage.Body);
			bodyElement.SearchProperties[HtmlControl.PropertyNames.TagName] = "option";
			bodyElement.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, article.Category, PropertyExpressionOperator.Contains);
			HtmlControl categoryElement = (HtmlControl) bodyElement.FindMatchingControls().FirstOrDefault();
			Keyboard.SendKeys(categoryElement, categoryElement.InnerText);
			Keyboard.SendKeys(categoryElement, "{ESCAPE}");

			// Hace clic en el botón buscar
			Mouse.Click(UISearchAdvancedPage.Body.ContainerSearch.ButtonSearch);

			return new ResultsSearch();
		}
	}
}
