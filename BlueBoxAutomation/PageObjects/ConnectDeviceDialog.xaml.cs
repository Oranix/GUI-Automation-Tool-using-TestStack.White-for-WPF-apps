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

namespace BlueBoxAutomation
{
    
    public partial class ConnectDeviceWindow : Window
    {
        public ConnectDeviceWindow(string message)
        {
            InitializeComponent();
            MessageText.Text = message; // message send 
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;   // User select Ok on button
            this.Close();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;   // User select Cancel on button
            this.Close();
        }
        public static bool? ShowDialogWindow(string message)
        {
            ConnectDeviceWindow window = new ConnectDeviceWindow(message);

            window.Topmost = true;   //Display the window above all other winodws 
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;   //Centers the dialog on the screen

            return window.ShowDialog();   // True / False / Null
        }
    }
}
