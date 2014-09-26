using System;
using System.Linq;

namespace Reto2ClassLibrary
{
    public class Reto2 : IReto2
    {
        /// <summary>
        /// El evento que contiene los delegados a los que invocar de manera ordenada
        /// </summary>
        private EventHandler eventFired;

        /// <summary>
        /// El evento al que sólo los objetos de tipo Item se pueden suscribir.
        /// Si no son de tipo Item se ignoran.
        /// </summary>
        public event EventHandler EventFired
        {
            add
            {
                if ((value != null) && (value.Target is Item))
                {
                    this.eventFired += value;

                    var orderedDelegates =
                        from oneDelegate in this.eventFired.GetInvocationList()
                        let item = oneDelegate.Target as Item
                        orderby item.Index
                        select oneDelegate;

                    this.eventFired = (EventHandler)Delegate.Combine(orderedDelegates.ToArray());
                }
            }

            remove
            {
                this.eventFired -= value;
            }
        }

        /// <summary>
        /// El método al que podemos llamar para lanzar el evento
        /// </summary>
        public void FireEvent()
        {
            if (this.eventFired != null)
            {
                this.eventFired(this, EventArgs.Empty);
            }
        }
    }
}
