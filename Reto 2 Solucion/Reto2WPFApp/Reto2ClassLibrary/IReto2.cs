using System;

namespace Reto2ClassLibrary
{
    /// <summary>
    /// El interfaz que tiene que implementar la clase del Reto 2
    /// </summary>
    public interface IReto2
    {
        /// <summary>
        /// El evento al que sólo los objetos de tipo Item se pueden suscribir.
        /// Si no son de tipo Item se ignoran.
        /// </summary>
        event EventHandler EventFired;

        /// <summary>
        /// El método al que podemos llamar para lanzar el evento
        /// </summary>
        void FireEvent();
    }
}
