using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace WpfPicoErp.Extension
{
    public static class WindowExtension
    {
        public static Window GetParentWindow( DependencyObject child)
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);
            if (parentObject == null)
            {
                return null;
            }
            else if (parentObject is Window parentWindow)
            {
                return parentWindow;
            }
            else
            {
                return GetParentWindow(parentObject);
            }
        }
    }
}
