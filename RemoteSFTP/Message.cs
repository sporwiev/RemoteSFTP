using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RemoteSFTP
{
    internal class Message
    {
        public void MessageInformation(object message)
        {
            MessageBox.Show(message.ToString(),"Information",MessageBoxButton.OK,MessageBoxImage.Information);
        }
        public void MessageWarning(object message)
        {
            MessageBox.Show(message.ToString(), "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        public void MessageError(object message)
        {
            MessageBox.Show(message.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
