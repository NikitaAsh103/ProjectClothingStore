using ProjectClothingStore.ClassHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static ProjectClothingStore.ClassHelper.EFclass;



namespace ProjectClothingStore.Pages.MainWindows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPages.xaml
    /// </summary>
    public partial class AuthorizationPages : Page
    {
        public AuthorizationPages()
        {
            InitializeComponent();
            
        }

        private void BtEnter_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = Contexts.User.ToList()
               .Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password).FirstOrDefault();

            if (userAuth != null)
            {
                MessageBox.Show("OK");
            }
            else
            {
                MessageBox.Show("Такого пользователя нет", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtRegister_Click(object sender, RoutedEventArgs e)
        {
            FrameData.frame.Navigate(new RegistrationPages());
        }
    }
}
