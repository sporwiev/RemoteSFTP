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
using Renci.SshNet;

namespace RemoteSFTP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            tabConfig.Focus();
            sftppanel.IsEnabled = false;
            databasepanel.IsEnabled = false;
            
        }
        
        public void getFiles(SSH ssh,string path)
        {
            //listdirectory.Items.Clear();
            listdirectory.Items.Add("...");
            foreach (var item in ssh.getConnection().ListDirectory(path))
            {
                listdirectory.Items.Add(item.Name);
            }
        }
        public string getToStorke(string text)
        {
            string[] a = text.Split('/');
            return a[a.Length];
        }
        private void listdirectory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            new Message().MessageInformation(sender);
            string addpath = (sender as ListBox).SelectedItem.ToString();
            if (addpath == "...")
            {
                string frompath = addpath.Substring(0,(addpath.IndexOf(getToStorke(Path.Text))));
                Path.Text = frompath;
                
            }
            else
            {
                Path.Text += "/" + addpath;
                
            }
            getFiles(new SSH(), Path.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SSH ssh = new SSH();
                int index = 1;
                foreach (var item in sftpbox.Children)
                {
                    if (item is TextBox && (item as TextBox).Text != null)
                    {
                        index++;
                    }
                }
                new Message().MessageInformation(index);
                if (index == 5)
                {
                    ssh.openConnection();
                    
                    //getFiles(ssh, Path.Text);
                    sftppanel.IsEnabled = true;
                    databasepanel.IsEnabled = true;


                }
                else
                {
                    new Message().MessageWarning("Подключение невозможно, введите данные для входа во вкладке 'Config'");

                }
            }
            catch (Exception ex)
            {
                new Message().MessageError(ex.ToString());
            }
        }
    }
}
