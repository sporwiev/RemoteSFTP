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

namespace RemoteSFTP
{
    /// <summary>
    /// Логика взаимодействия для Config.xaml
    /// </summary>
    public partial class Config : Window
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                SSH ssh = new SSH();
                if (!ssh.getConnection().IsConnected)
                {
                    ssh.openConnection();
                }
                new MainWindow().Show();
            }catch (Exception ex) 
            {
                new Message().MessageError(ex.Message);
                new Config().Show();
            }
        }
    }
}
