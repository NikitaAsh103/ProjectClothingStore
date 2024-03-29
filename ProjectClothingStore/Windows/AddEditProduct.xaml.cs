﻿using System;
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
using System.IO;
using Microsoft.Win32;

namespace ProjectClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Window
    {
        private string pathImageProduct = null;
        private bool isEdit = false;
        Product editProduct;

        public AddEditProduct()
        {
            InitializeComponent();

            CmbCategory.ItemsSource = EFclass.Contexts.Category.ToList();
            CmbCategory.DisplayMemberPath = "Name";
            CmbCategory.SelectedIndex = 0;

            CmbColor.ItemsSource = EFclass.Contexts.Color.ToList();
            CmbColor.DisplayMemberPath = "TitleColor";
            CmbColor.SelectedIndex = 0;

            CmbSize.ItemsSource = EFclass.Contexts.Size.ToList();
            CmbSize.DisplayMemberPath = "Size1";
            CmbSize.SelectedIndex = 0;


        }

        public AddEditProduct(Product product)
        {
            InitializeComponent();

            // Заполнение комбобокса

            CmbCategory.ItemsSource = EFclass.Contexts.Category.ToList();
            CmbCategory.DisplayMemberPath = "TitleCategory";
            CmbCategory.SelectedIndex = 0;

            CmbColor.ItemsSource = EFclass.Contexts.Color.ToList();
            CmbColor.DisplayMemberPath = "TitleColor";
            CmbColor.SelectedIndex = 0;

            CmbSize.ItemsSource = EFclass.Contexts.Size.ToList();
            CmbSize.DisplayMemberPath = "TitleSize";
            CmbSize.SelectedIndex = 0;

            // заполнение полей значениями 
            TbName.Text = product.Name;
            TbPrice.Text = product.Price.ToString();
            CmbCategory.SelectedItem = EFclass.Contexts.Category.ToList().Where(i => i.IDCategory == product.IDCategory).FirstOrDefault();

            // вывод фото

            if (product.ProductImage != null)
            {
                using (MemoryStream ms = new MemoryStream(product.ProductImage))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                    ImgProduct.Source = bitmapImage;
                }
            }


            // Изменение заголовка и кнопки 

            TblockTitle.Text = "Изменение товара";
            BtnAddProduct.Content = "Изменить";

            // флаг на изменение
            isEdit = true;

            // выводим из контекста класса полученный продукт
            editProduct = product;
        }



        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImageProduct = openFileDialog.FileName;
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // валидация 

            if (isEdit)
            {
                // редактирование

                editProduct.Name = TbName.Text;
                editProduct.Price = Convert.ToDecimal(TbPrice.Text);
                editProduct.IDCategory = (CmbCategory.SelectedItem as Category).IDCategory;
                if (pathImageProduct != null)
                {
                    editProduct.ProductImage = File.ReadAllBytes(pathImageProduct);
                }

                EFclass.Contexts.SaveChanges();

                MessageBox.Show("Товар успешно изменен");


            }
            else
            {
                // добавление
                Product product = new Product();
                product.Name = TbName.Text;
                product.Price = Convert.ToDecimal(TbPrice.Text);
                product.IDCategory = (CmbCategory.SelectedItem as Category).IDCategory;
                if (pathImageProduct != null)
                {
                    product.ProductImage = File.ReadAllBytes(pathImageProduct);
                }

                EFclass.Contexts.Product.Add(product);
                EFclass.Contexts.SaveChanges();

                MessageBox.Show("Товар добавлен");
            }


            this.Close();
        }
    }
}
