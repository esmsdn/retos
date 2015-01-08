namespace SudokuApp
{
    using Microsoft.Practices.Unity;
    using Portable.Services;
    using Portable.ViewModels;
    using Services;

    /// <summary>
    /// Instanciamos un objeto de esta clase en el App.xaml para que las vistas puedan localizar sus 
    /// vista-modelo correspondientes. Cada vez que una vista pida su vista-modelo (en esta app lo 
    /// hacen directamente en su XAML), dicho vista-modelo se instanciará si es necesario y se le 
    /// pasarán los servicios de los que dependa según hayamos indicado en su constructor
    /// </summary>
    public class ServiceLocator
    {
        private UnityContainer container = new UnityContainer();

        public ServiceLocator()
        {
            container.RegisterType<INavigationService, NavigationService>();
            container.RegisterType<SudokuService>();
            container.RegisterType<MessagingService>();

            container.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager());
            container.RegisterType<HelpViewModel>();
        }

        public MessagingService MessagingService { get { return container.Resolve<MessagingService>(); } }

        public MainViewModel MainViewModel { get { return container.Resolve<MainViewModel>(); }  }

        public HelpViewModel HelpViewModel { get { return container.Resolve<HelpViewModel>(); } }
    }
}
