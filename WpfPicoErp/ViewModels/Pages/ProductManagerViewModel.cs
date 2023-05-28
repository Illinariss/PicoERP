using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPicoErp.Context;
using WpfPicoErp.Misc;
using WpfPicoErp.Models;
using WpfPicoErp.ViewModels.Windows;
using WpfPicoErp.Windows;

namespace WpfPicoErp.ViewModels.Pages
{
    public partial class ProductManagerViewModel : ViewModelBase
    {
        public ProductManagerViewModel()
        {
            PicoContext = new PicoDbContext();
            DeleteProductCommand = new ParameteredRelayCommand(DeleteProduct, ProductExists);
            OpenEditProductWindowCommand = new ParameteredRelayCommand(EditProduct, ProductExists);
            OpenAddProductWindowCommand = new ParameteredRelayCommand(AddProduct);

            LoadData();
        }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }


        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                Debug.WriteLine("SelectedProduct changed");
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private void LoadData()
        {
            Products = new ObservableCollection<Product>(PicoContext.Products.ToList());
            
        }

        private void AddProduct(object parameter)
        {
            SelectedProduct = new Product();
            var addProductViewModel = new AddEditProductViewModel(SelectedProduct);
            var addProductWindow = new AddEditProductWindow { DataContext = addProductViewModel };
            addProductViewModel.CancelCommand = new RelayCommand(() =>
            {
                SelectedProduct = null;
                addProductWindow.Close();
            });
            addProductViewModel.SaveCommand = new RelayCommand(() =>
            {
                PicoContext.Add(SelectedProduct);
                if (PicoContext.SaveChanges() > 0)
                {
                    Products.Add(SelectedProduct);
                }
                else
                {
                    //todo: fehlermeldung speichern fehlgeschlagen.
                }
                addProductWindow.Close();
            });
            addProductWindow.ShowDialog();
        }

        private void EditProduct(object parameter)
        {
            if (SelectedProduct != null)
            {
                var addProductViewModel = new AddEditProductViewModel(SelectedProduct);
                var addProductWindow = new AddEditProductWindow { DataContext = addProductViewModel };
                addProductViewModel.CancelCommand = new RelayCommand(() => {
                    PicoContext.Entry(SelectedProduct).Reload();
                    addProductWindow.Close();
                });
                addProductViewModel.SaveCommand = new RelayCommand(() =>
                {
                    if (PicoContext.SaveChanges() > 0)
                    {
                        addProductWindow.Close();
                    }
                    else
                    {
                        //todo: fehlermeldung speichern fehlgeschlagen.
                    }
                });
                addProductWindow.ShowDialog();
            }
        }

        private bool ProductExists(object parameter) => SelectedProduct != null;

        private void DeleteProduct(object parameter)
        {
            if (SelectedProduct != null)
            {
                PicoContext.Remove(SelectedProduct);
                Products.Remove(SelectedProduct);
            }
        }

        public PicoDbContext PicoContext { get; private set; }
        public ParameteredRelayCommand DeleteProductCommand { get; private set; }
        public ParameteredRelayCommand OpenEditProductWindowCommand { get; private set; }
        public ParameteredRelayCommand OpenAddProductWindowCommand { get; private set; }
        
    }
}
