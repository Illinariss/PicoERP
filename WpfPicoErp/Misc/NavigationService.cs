using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfPicoErp.Interfaces;
using WpfPicoErp.ViewModels;

namespace WpfPicoErp.Misc
{
    public class NavigationService : INavigationService
    {
        private readonly Frame _navigationFrame;
        private readonly Dictionary<Type, Type> _mappings;


        public NavigationService(Frame navigationFrame)
        {
            _navigationFrame = navigationFrame;
            _mappings = new Dictionary<Type, Type>();
        }

        public void Register<TViewModel, TView>() where TViewModel : ViewModelBase where TView : FrameworkElement
        {
            _mappings[typeof(TViewModel)] = typeof(TView);
        }

        public void Navigate<TViewModel>() where TViewModel : ViewModelBase, new()
        {
            var viewType = _mappings[typeof(TViewModel)];

            if (viewType != null)
            {
                var view = Activator.CreateInstance(viewType) as FrameworkElement;
                var vm = new TViewModel();
                view.DataContext = vm;                                
                _navigationFrame.Navigate(view);
                _navigationFrame.NavigationService.RemoveBackEntry();
            }
        }
        
    }

}
