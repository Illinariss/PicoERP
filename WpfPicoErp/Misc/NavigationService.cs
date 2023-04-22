using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfPicoErp.Interface;
using WpfPicoErp.ViewModels;

namespace WpfPicoErp.Misc
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> _viewModelViewMap = new Dictionary<Type, Type>();
        private readonly Window _mainWindow;

        public NavigationService(Window mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void Register<TViewModel, TView>()
            where TViewModel : ViewModelBase
            where TView : FrameworkElement
        {
            _viewModelViewMap[typeof(TViewModel)] = typeof(TView);
        }

        public void NavigateTo<TViewModel>()
            where TViewModel : ViewModelBase, new()
        {
            if (!_viewModelViewMap.TryGetValue(typeof(TViewModel), out var viewType))
            {
                throw new InvalidOperationException($"No view registered for ViewModel '{typeof(TViewModel)}'");
            }

            var viewModel = new TViewModel();
            var view = (FrameworkElement)Activator.CreateInstance(viewType);
            view.DataContext = viewModel;
            _mainWindow.Content = view;
        }

    }
}
