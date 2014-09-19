using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;

namespace ETWClassLibrary
{
    /// <summary>
    /// Fuente de eventos usados para tracing dentro de la aplicación
    /// </summary>
    [EventSource(Name = "Reto2")]
    public class ETWEventSource : EventSource
    {
        /// <summary>
        /// La fuente de eventos por defecto
        /// </summary>
        private static ETWEventSource log = new ETWEventSource();

        /// <summary>
        /// Devuelve la fuente de eventos por defecto
        /// </summary>
        public static ETWEventSource Log
        {
            get
            {
                return log;
            }
        }

        /// <summary>
        /// Escribe un evento de nivel Critical (el más importante)
        /// </summary>
        /// <param name="module">El módulo que ha escrito el evento</param>
        /// <param name="message">El mensaje del evento</param>
        [Event(1, Message = "[{0}] Critical: {1}", Level = EventLevel.Critical)]
        public void Critical(string module, string message)
        {
            WriteEvent(1, module, message);
        }

        /// <summary>
        /// Escribe un evento de nivel Error
        /// </summary>
        /// <param name="module">El módulo que ha escrito el evento</param>
        /// <param name="message">El mensaje del evento</param>
        [Event(2, Message = "[{0}] Error: {1}", Level = EventLevel.Error)]
        public void Error(string module, string message)
        {
            WriteEvent(2, module, message);
        }

        /// <summary>
        /// Escribe un evento de nivel Warning
        /// </summary>
        /// <param name="module">El módulo que ha escrito el evento</param>
        /// <param name="message">El mensaje del evento</param>
        [Event(3, Message = "[{0}] Warning: {1}", Level = EventLevel.Warning)]
        public void Warning(string module, string message)
        {
            WriteEvent(3, module, message);
        }

        /// <summary>
        /// Escribe un evento de nivel Informational
        /// </summary>
        /// <param name="module">El módulo que ha escrito el evento</param>
        /// <param name="message">El mensaje del evento</param>
        [Event(4, Message = "[{0}] Informational: {1}", Level = EventLevel.Informational)]
        public void Informational(string module, string message)
        {
            WriteEvent(4, module, message);
        }

        /// <summary>
        /// Escribe un evento de nivel Verbose (el menos importante)
        /// </summary>
        /// <param name="module">El módulo que ha escrito el evento</param>
        /// <param name="message">El mensaje del evento</param>
        [Event(5, Message = "[{0}] Verbose: {1}", Level = EventLevel.Verbose)]
        public void Verbose(string module, string message)
        {
            WriteEvent(5, module, message);
        }
    }
}
