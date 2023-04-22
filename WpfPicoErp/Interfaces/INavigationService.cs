using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfPicoErp.ViewModels;

namespace WpfPicoErp.Interfaces
{
    public interface INavigationService
    {
    

        void Register<TViewModel, TView>() where TViewModel : ViewModelBase where TView : FrameworkElement;
        void Navigate<TViewModel>() where TViewModel : ViewModelBase, new();
    }


}
