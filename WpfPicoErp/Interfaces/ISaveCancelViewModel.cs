using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfPicoErp.Interfaces
{
    public interface ISaveCancelViewModel
    {
        ICommand SaveCommand { get; set; }
        ICommand CancelCommand { get; set; }
    }
}
