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
using System.Windows.Shapes;

using ProjectClothingStore.ClassHelper;
using ProjectClothingStore.Windows;
using ProjectClothingStore.DB;

namespace ProjectClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();

            GetListProduct();
        }

        private void GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = EFclass.Contexts.Product.ToList();

            LvProduct.ItemsSource = products;
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // переход на окно добавления товара
            AddEditProduct addEditProductWindow = new AddEditProduct();
            addEditProductWindow.ShowDialog();

            GetListProduct();
        }

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;

            AddEditProduct addEditProductWindow = new AddEditProduct(selectedProduct);
            addEditProductWindow.ShowDialog();

            GetListProduct();

        }
    }
}
