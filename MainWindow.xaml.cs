using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WpfLibrary1;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Matrix<int> matr = new Matrix<int>(0,0);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Fill_Matrix_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Column_Matrix_Textbox.Text, out int n))
            {
                MessageBox.Show("Введите правильное количество столбцов");
            }
            if (!int.TryParse(String_Matrix_Textbox.Text, out n))
            {
                MessageBox.Show("Введите правильное количество строк");
            }
            if (!int.TryParse(Min_Matrix_Range_Textbox.Text, out n))
            {
                MessageBox.Show("Введите правильный диапазон");
            }
            if (!int.TryParse(Max_Matrix_Range_Textbox.Text, out n))
            {
                MessageBox.Show("Введите правильный диапазон");
            }
            else
            {
                int min = Convert.ToInt32(Min_Matrix_Range_Textbox.Text);
                int max = Convert.ToInt32(Max_Matrix_Range_Textbox.Text);
                int rows = Convert.ToInt32(String_Matrix_Textbox.Text);
                int cols = Convert.ToInt32(Column_Matrix_Textbox.Text);
                matr = new Matrix<int>(rows, cols);
                ExtensionMatrix.FillMatrix(matr, rows, cols, min, max);
                //Random rnd = new();
                //for (int i = 0; i < matr.Rows; i++)
                //{
                //    for (int j = 0; j < matr.Columns; j++)
                //    {
                //        matr[i, j] = rnd.Next(min, max);
                //    }
                //}
                DataGrid.ItemsSource = matr.ToDataTable().DefaultView;
            }
        }

        private void Count_Matrix_Button_Click(object sender, RoutedEventArgs e)
        {
            Result_Matrix_Textbox.Clear();
            int sum = 0;
            sum = WpfLibrary1.ExtensionMatrix.Count(matr);
            Result_Matrix_Textbox.Text = sum.ToString();
        }

        private void About_Program_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Халимов Виктор\nПрактическая работа №2\nНайти разницу чисел\nРезультат вывести на экран");
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            matr.Save(@".\object.matrix");
            //SaveFileDialog save = new SaveFileDialog();
            //save.DefaultExt = ".matrix";
            //save.Filter = "Все файлы (*.*) | *.* | Матрицы | *.matrix*";
            //save.FilterIndex = 2;
            //save.Title = "Сохранение таблицы";
            //if (save.ShowDialog()== true)
            //{
            //    
            //
            //StreamWriter file = new StreamWriter(save.FileName);
            //
            //
            //}
            
        }

        private void Open_Button_Click(object sender, RoutedEventArgs e)
        {
            matr.Load(@".\object.matrix");
            DataGrid.ItemsSource = matr.ToDataTable().DefaultView;
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Clear_Matrix_Button_Click(object sender, RoutedEventArgs e)
        {
            matr.DefaultInit();
            DataGrid.ItemsSource = null;
            Min_Matrix_Range_Textbox.Clear();
            Max_Matrix_Range_Textbox.Clear();
            String_Matrix_Textbox.Clear();
            Column_Matrix_Textbox.Clear();
            Result_Matrix_Textbox.Clear();
        }
    }
}
