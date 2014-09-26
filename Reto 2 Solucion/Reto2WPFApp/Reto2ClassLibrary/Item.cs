using ETWClassLibrary;
using System.Diagnostics;

namespace Reto2ClassLibrary
{
    /// <summary>
    /// Uno de los ítems que se corresponden con los botones del interfaz
    /// </summary>
    public class Item
    {
        /// <summary>
        /// El índice que determina en qué orden se ejecuta el manejador del evento
        /// de entre todos los suscritos al evento
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// El manejador del evento del reto
        /// </summary>
        /// <param name="sender">No se utiliza</param>
        /// <param name="e">No se utiliza</param>
        public void OnEvent(object sender, System.EventArgs e)
        {
            ETWEventSource.Log.Verbose("Reto2ClassLibrary", string.Format("OnEvent Item {0}", Index));
        }
    }
}
