using Microsoft.Win32;
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
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string[] paths, files;
        MediaPlayer player = new MediaPlayer();
       
        private void megnyitBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd= new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == true)
            {
                files = ofd.SafeFileNames;
                paths = ofd.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    listBox.Items.Add(files[i]);
                }
            }
            megnyitBtn.Content = "Új zene felvétele";
            
           

            
        }

        private void inditBtn_Click(object sender, RoutedEventArgs e)
        {
            zeneNeve.Content = listBox.SelectedItem;
            player.Play();
            
           
            
            

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            player.Open(new Uri(paths[listBox.SelectedIndex]));
            
        }

        private void megallitBtn_Click(object sender, RoutedEventArgs e)
        {
           
            player.Pause();
        }

        private void hangeroSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = hangeroSlider.Value;
        }

        private void torolBtn_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Remove(listBox.SelectedItem);
        }

        private void kovetkezoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex<listBox.Items.Count-1)
            {
                listBox.SelectedIndex = listBox.SelectedIndex + 1;
            }
        }

        private void elozoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedIndex>0)
            {
                listBox.SelectedIndex = listBox.SelectedIndex - 1;
            }
        }

        

        
    }
}
