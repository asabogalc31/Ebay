using Belatrix.Ebay.API.Components;
using Belatrix.Ebay.API.Screens.Results.Extension;
using Belatrix.Ebay.API.Screens.Results.Model;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Belatrix.Ebay.API.Screens.Results.ResultsSearchClasses
{
	/// <summary>
	/// Representa la acciones en la pantalla "Resultados de búsqueda"
	/// </summary>
	public partial class ResultsSearch
	{
		/// <summary>
		/// Selecciona la talla
		/// </summary>
		/// <param name="size">La talla</param>
		/// <returns><see cref="ResultsSearch"/></returns>
		public ResultsSearch SelectSize(int size)
		{
			// Busca el elemento de la talla
			HtmlControl containerSize = new HtmlControl(UIResultsPage.Body.ContainerPane.ContainerSize);
			containerSize.SearchProperties[HtmlControl.PropertyNames.TagName] = "span";
			containerSize.SearchProperties.Add(HtmlControl.PropertyNames.InnerText, size.ToString(), PropertyExpressionOperator.Contains);
			UITestControl sizeElement = containerSize.FindMatchingControls().FirstOrDefault();

			// Selecciona la talla
			UITestControl parent = sizeElement.GetParent();
			Mouse.Click(parent);

			// Imprime el número de resultados
			Thread.Sleep(TimeSpan.FromSeconds(5));
			HtmlControl numberResultsElement = UIResultsPage.Body.HeaderResults.NumberResults;
			string numberResults = numberResultsElement.InnerText;
			string msg = string.Format("La cantidad de resultados con la talla {0} es de {1}",
				size.ToString(),
				numberResultsElement);
			Console.WriteLine(msg);
			
			return new ResultsSearch();
		}

		/// <summary>
		/// Ordena ascendentemente los precios
		/// </summary>
		/// <returns><see cref="ResultsSearch"/></returns>
		public ResultsSearch SortByAscendantPrice()
		{
			EnumSortResults byAscendantPrice = EnumSortResults.ByAscendantPrice;
			SortResults(byAscendantPrice.GetAttribute<ByPrice>().SortByPrice);
			return new ResultsSearch();
		}

		/// <summary>
		/// Ordena descendentemente los precios
		/// </summary>
		/// <returns><see cref="ResultsSearch"/></returns>
		public ResultsSearch SortByDescendantPrice()
		{
			EnumSortResults byDescendantPrice = EnumSortResults.ByDescendantPrice;
			SortResults(byDescendantPrice.GetAttribute<ByPrice>().SortByPrice);
			return new ResultsSearch();
		}

		/// <summary>
		/// Obtiene la cantidad de productos
		/// </summary>
		/// <param name="quantity">La cantidad</param>
		/// <returns><see cref="Article"/></returns>
		public ResultsSearch GetProducts(int quantity)
		{
			Thread.Sleep(TimeSpan.FromSeconds(5));
			HtmlControl body = new HtmlControl(UIResultsPage.Body);
			body.SearchProperties[HtmlControl.PropertyNames.Id] = "ListViewInner";
			UITestControl ulElement = body.FindMatchingControls().FirstOrDefault();
			UITestControlCollection listProductsChildren = ulElement.GetChildren();
			IEnumerable<UITestControl> CollectionProducts = listProductsChildren.Take(quantity);

			// Obtiene el nombre y precio de cada uno de los productos y lo asigna al listado
			int aux = 0;

			foreach (HtmlControl product in CollectionProducts)
			{
				aux += 1;
				string msg = string.Format("Información del producto {0}", aux);
				Console.WriteLine(msg);
				Article article = new Article();

				// Nombre del producto
				HtmlControl productElement = product;
				productElement.SearchProperties[HtmlControl.PropertyNames.TagName] = "h3";
				productElement.SearchProperties[HtmlControl.PropertyNames.Class] = "lvtitle";
				productElement.FindMatchingControls();
				string name = string.Format("    Nombre: {0}", productElement.InnerText);
				Console.WriteLine(name);

				// Precio del producto
				product.SearchProperties[HtmlControl.PropertyNames.TagName] = "li";
				product.SearchProperties[HtmlControl.PropertyNames.Class] = "lvprice prc";
				product.FindMatchingControls();
				string price = string.Format("    Precio: {0}", product.InnerText);
				Console.WriteLine(price);
			}

			return new ResultsSearch();
		}

		/// <summary>
		/// Ordena por precio de forma ascendente
		/// </summary>
		/// <param name="typeSorting">Tipo de ordenamiento</param>
		private void SortResults(string typeSorting)
		{
			// Despliega el listado para ordenar
			Mouse.Click(UIResultsPage.Body.ContainerOrderBy.OrderBy);

			// Selecciona la opción de ordenamiento
			HtmlControl listOrderBy = new HtmlControl(UIResultsPage.Body.ContainerOrderBy);
			listOrderBy.SearchProperties[HtmlControl.PropertyNames.InnerText] = typeSorting;
			listOrderBy.SearchProperties[HtmlControl.PropertyNames.TagName] = "a";
			UITestControl elementOrderBy = listOrderBy.FindMatchingControls().FirstOrDefault();
			Mouse.Click(elementOrderBy);
		}
	}
}
