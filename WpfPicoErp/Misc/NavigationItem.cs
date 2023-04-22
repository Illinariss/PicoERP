using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPicoErp.Interfaces;
using WpfPicoErp.ViewModels;

namespace WpfPicoErp.Misc
{
    public class NavigationItem : INavigationItem
    {
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public Type ViewModelType { get; set; }
        private readonly INavigationService _navigationService;

        public NavigationItem(string name, Action navigateAction, INavigationService navigationService, Type viewModelType, string imagePath = null)
        {
            Name = name;
            _navigationService = navigationService;
            NavigateCommand = new RelayCommand(navigateAction);
            ImagePath = imagePath;
            ViewModelType = viewModelType;
        }

        public ICommand NavigateCommand { get; }
    }
}
