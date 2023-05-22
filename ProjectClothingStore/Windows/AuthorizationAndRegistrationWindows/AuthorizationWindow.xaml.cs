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
using System.Windows.Shapes;
using static ProjectClothingStore.ClassHelper.EFclass;

namespace ProjectClothingStore.Windows.AuthorizationAndRegistrationWindows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void BtEnter_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = Contexts.User.ToList()
               .Where(i => i.Login == TbLogin.Text && i.Password == PbPassword.Password).FirstOrDefault();

            // проверка на работника
            if (userAuth != null)
            {
                // сохранияем данные входа
                ClassHelper.UserDataClass.User = userAuth;

                var emplAuth = Contexts.Employee.Where(i => i.IDUser == userAuth.IDUser).FirstOrDefault();
                if (emplAuth != null)
                {


                    // сохраняем данные входа для Сотрудника

                    ClassHelper.UserDataClass.Employee = emplAuth;

                    // проверка роли 

                    switch (emplAuth.IDPosition)
                    {
                        case 1:
                            // переход на страницу директора
                            DirectorWindows directorWindow = new DirectorWindows();
                            var mainWindow = new MainWindow();
                            this.Close();
                            directorWindow.Show();

                            break;

                        case 2:
                            // переход на страницу администратора
                            break;
                        case 3:
                            // переход на страницу продавца
                            ProductListWindow productWindow = new ProductListWindow();
                            productWindow.Show();
                            this.Close();
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    // Client

                    // сохраняем клиента
                    //ClassHelper.UserDataClass.Client = userAuth;


                    ProductListWindow productListWindow = new ProductListWindow();
                    productListWindow.Show();
                    this.Close();


                }


            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtRegister_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationwindow = new RegistrationWindow();
            registrationwindow.Show();
            this.Close();
        }
    }
}
