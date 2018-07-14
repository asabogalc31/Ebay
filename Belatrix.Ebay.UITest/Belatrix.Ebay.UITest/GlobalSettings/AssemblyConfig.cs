using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Belatrix.Ebay.UITest.GlobalSettings
{
	/// <summary>
	/// Contiene la configuración general para la ejecución de las pruebas
	/// </summary>
	[CodedUITest]
	public class AssemblyConfig
	{
		/// <summary>
		/// Establece una instancia
		/// </summary>
		protected AssemblyConfig()
		{
		}

		/// <summary>
		/// Realiza la configuración global de las pruebas
		/// </summary>
		[AssemblyInitialize()]
		public static void GlobalSettings(TestContext context)
		{
			// Activa la ejecución rápida de las pruebas
			Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.Disabled;

			// El tiempo en segundos a esperar a encontrar un elemento
			Playback.PlaybackSettings.MaximumRetryCount = 10;

			// Espera hasta que la página cargue completamente
			Playback.PlaybackSettings.ShouldSearchFailFast = false;

			// Tiempo a esperar entre acciones
			Playback.PlaybackSettings.DelayBetweenActions = 0;

			// Tiempo de búsqueda de los elementos
			Playback.PlaybackSettings.SearchTimeout = 1000;

			// Habilita la captura de pantalla para el nivel de seguimiento predeterminado
			Playback.PlaybackSettings.LoggerOverrideState = HtmlLoggerState.DefaultTraceLevel;

			// Habilita el envío de claves como scancode
			Playback.PlaybackSettings.SendKeysAsScanCode = true;

			// Busca en ventanas minimizadas
			Playback.PlaybackSettings.SearchInMinimizedWindows = false;

			// La búsqueda de elementos coincide exactamente con la jerarquía
			Playback.PlaybackSettings.MatchExactHierarchy = true;

			// Ejecuta más rápido las pruebas
			Playback.PlaybackSettings.ShouldSearchFailFast = true;
		}
	}
}
