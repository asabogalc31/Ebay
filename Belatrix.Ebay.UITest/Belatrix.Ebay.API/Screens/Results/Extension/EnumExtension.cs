using System;
using System.Linq;

namespace Belatrix.Ebay.API.Screens.Results.Extension
{
	/// <summary>
	/// Representa las extensiones de los enumeradores
	/// </summary>
	internal static class EnumExtension
	{
		/// <summary>
		/// Obtiene el valor del atributo especificado
		/// </summary>
		/// <typeparam name="TAttribute"><see cref="TAttribute"/></typeparam>
		/// <param name="value">El enumerador</param>
		/// <returns>Un objeto con el primer atributo del enumerador</returns>
		public static TAttribute GetAttribute<TAttribute>(this Enum value)
			where TAttribute : Attribute
		{
			Type enumType = value.GetType();
			string forAttribute = Enum.GetName(enumType, value);
			return enumType.GetField(forAttribute).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
		}
	}
}
