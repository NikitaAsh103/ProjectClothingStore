using ProjectClothingStore.DB;
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



namespace ProjectClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для DirectorWindows.xaml
    /// </summary>
    public partial class DirectorWindows : Window
    {
        List<Employee> employees = new List<Employee>();
        public DirectorWindows()
        {
            InitializeComponent();
            lvEmployee.ItemsSource = null;
        }
        
        private void btnEmployee_Click(object sender, RoutedEventArgs e)
        {
            lvEmployee.ItemsSource = EFclass.Contexts.Employee.ToList();
        }
    }
}
