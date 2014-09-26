using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace ETWClassLibrary
{
    /// <summary>
    /// Escucha eventos de tracing y los muestra en la consola de depuración de Visual Studio
    /// </summary>
    public class ETWDebugEventListener : EventListener
    {
        /// <summary>
        /// El objeto por defecto para escuchar los eventos
        /// </summary>
        private static ETWDebugEventListener listen = new ETWDebugEventListener();

        /// <summary>
        /// Devuelve el objeto por defecto para escuchar los eventos
        /// </summary>
        public static ETWDebugEventListener Listen
        {
            get
            {
                return listen;
            }
        }

        /// <summary>
        /// Se ha escrito un evento en alguna fuente de eventos de tracing. Lo mostramos
        /// </summary>
        /// <param name="eventData">Los datos del evento de tracing</param>
        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            Debug.WriteLine(string.Format(eventData.Message, eventData.Payload[0], eventData.Payload[1]));
        }
    }
}
