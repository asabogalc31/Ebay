using Belatrix.Ebay.API.Screens.Home.HomeClasses;
using Belatrix.Ebay.UITest.Data;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Belatrix.Ebay.UITest.Test
{
	/// <summary>
	/// Summary description for CodedUITest1
	/// </summary>
	[CodedUITest]
	public class SortArticles
	{
		/// <summary>
		/// Obtiene o establece el navegador
		/// </summary>
		public BrowserWindow Browser { get; set; }

		/// <summary>
		/// Abre el navegador
		/// </summary>
		[TestInitialize()]
		public void LaunchBrowser()
		{
			BrowserWindow.CurrentBrowser = DataSource.currentBrowser;
			Browser = BrowserWindow.Launch(new Uri(DataSource.url));
			Browser.Maximized = true;
		}

		[TestMethod]
		public void SortShoes()
		{
			Home home = new Home();

			home.SelectAdvancedSearch()
				.SearchArticle(DataSource.Article)
				.SelectSize(DataSource.size)
				.SortByAscendantPrice()
				.GetProducts(5)
				.SortByDescendantPrice()
				.GetProducts(5);
		}
	}
}
