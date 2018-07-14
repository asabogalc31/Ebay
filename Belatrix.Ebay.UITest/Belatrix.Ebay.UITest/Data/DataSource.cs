using Belatrix.Ebay.API.Components;

namespace Belatrix.Ebay.UITest.Data
{
	public class DataSource
	{
		public static readonly string currentBrowser = "IE";
		public static readonly string url = "https://www.ebay.com/";
		public static Article Article
		{
			get
			{
				return new Article
				{
					KeyWord = "PUMA",
					Category = "calzado"
				};
			}
		}
		public static readonly int size = 10;
	}
}
