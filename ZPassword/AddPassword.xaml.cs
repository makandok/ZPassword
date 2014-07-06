using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Z10PasswordVault
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddPassword : Window
    {
        public AddPassword()
        {
            InitializeComponent();
        }

        public Action<string> ShowPasswordViewer;
        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
            if(ShowPasswordViewer!=null)
            {
                ShowPasswordViewer(txtSiteName.Text);
            }
        }

        private void btnSaveSite_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
