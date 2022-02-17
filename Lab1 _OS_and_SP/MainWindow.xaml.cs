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

namespace Lab1__OS_and_SP
{
    public partial class MainWindow : Window
    {
        private string Path = "";
        public Encoding format;

        public MainWindow()
        {
            InitializeComponent();
        }

        

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;            
            
            if (comboBox.SelectedIndex == 0)
            {
                format = Encoding.ASCII;
            }
            else if(comboBox.SelectedIndex == 1)
            {
                format = Encoding.Unicode;
            }
            if(Path != "")
            {
                if (comboBox.SelectedIndex == 0)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(Path, Encoding.ASCII))
                        {
                            OriginalTextBox.Text = sr.ReadToEnd();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (comboBox.SelectedIndex == 1)
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(Path, Encoding.Unicode))
                        {
                            OriginalTextBox.Text = sr.ReadToEnd();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Path = openFileDialog.FileName;
            }

            try
            {
                using (StreamReader sr = new StreamReader(Path, format))
                {
                    OriginalTextBox.Text = sr.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
