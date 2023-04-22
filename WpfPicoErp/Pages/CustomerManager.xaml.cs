using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfPicoErp.Context;
using WpfPicoErp.Models;
using WpfPicoErp.Windows;
using WpfPicoErp.Extension;

namespace WpfPicoErp.Pages
{
    /// <summary>
    /// Interaktionslogik für CustomerManager.xaml
    /// </summary>
    public partial class CustomerManager : Page
    {
        public CustomerManager()
        {
           // InitializeComponent();
        }

        private void OpenAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            // ShowAddCustomerDialog();
        }
       

        //private void ShowAddCustomerDialog()
        //{
        //    AddCustomerWindow addCustomerDialog = new AddCustomerWindow();
        //    Window parentWindow = WindowExtension.GetParentWindow(this); // Get the parent window of the current page
        //    if (parentWindow != null)
        //    {
        //        addCustomerDialog.Owner = parentWindow;
        //    }
        //    bool? result = addCustomerDialog.ShowDialog();

        //    if (result.HasValue && result.Value)
        //    {
        //        // Handle the new customer information here
        //        var newCustomer = new Customer();
        //        newCustomer.FirstName = addCustomerDialog.FirstNameTextBox.Text;
        //        newCustomer.LastName = addCustomerDialog.LastNameTextBox.Text;
        //        newCustomer.Email = addCustomerDialog.EmailTextBox.Text;

        //        this.AddItem(newCustomer);
        //    }
        //    addCustomerDialog.Close();
        //}

        private void OpenRemove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
