namespace SudokuApp.Portable.ViewModels.Base
{
    /// <summary>
    /// La clase de la que todo vista-modelo tiene que heredar
    /// </summary>
    public class BaseViewModel : ObservableObject
    {
        /// <summary>
        /// Se invoca cuando se navega a la vista asociada a este vista-modelo
        /// </summary>
        /// <param name="navigationContext">Los parámetros pasados por el vista-modelo desde el que hemos navegado a éste</param>
        public virtual void OnNavigatedTo(object navigationContext)
        {
        }

        /// <summary>
        /// Se invoca cuando se navega fuera de la vista asociada a este vista-modelo
        /// </summary>
        public virtual void OnNavigatedFrom()
        {
        }
    }
}
