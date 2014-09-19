using ETWClassLibrary;
using System.Diagnostics.Tracing;
using System.Windows;

namespace Reto2WPFApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public App()
        {
#if DEBUG
            ETWDebugEventListener debugListener = new ETWDebugEventListener();
            debugListener.EnableEvents(ETWEventSource.Log, EventLevel.LogAlways);
#endif
        }
    }
}
