namespace SudokuApp.Portable.ViewModels.Base
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// La clase de la que tiene que heredar todo objeto que quiera notificar a otro cuando una de sus propiedades cambie
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged
    {
        /// <summary>
        /// Evento al que podemos subscribirnos para ser notificados cuando una propiedad cambie
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Cambia el valor de una propiedad
        /// </summary>
        /// <typeparam name="T">El tipo de la propiedad</typeparam>
        /// <param name="storage">El campo que almacenará el valor de la propiedad</param>
        /// <param name="value">El nuevo valor de la propiedad</param>
        /// <param name="propertyName">El nombre de la propiedad</param>
        /// <returns>'True' si el valor ha cambiado; 'Falso' si no lo ha hecho</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Notifica a los subscriptores del evento <see cref="PropertyChanged"/> de un cambio en el valor de una propiedad
        /// </summary>
        /// <param name="propertyName">El nombre de la propiedad</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
