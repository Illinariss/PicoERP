using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfPicoErp.Interfaces;
using WpfPicoErp.Models;

namespace WpfPicoErp.ViewModels.Windows
{
    public partial class AddEditProductViewModel : ViewModelBase, ISaveCancelViewModel
    {
        public AddEditProductViewModel(Product selectedProduct)
        {
            Product = selectedProduct;
        }

        public Product Product { get; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
