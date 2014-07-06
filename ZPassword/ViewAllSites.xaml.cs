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
    public partial class ViewAllSites : Window
    {
        public ViewAllSites()
        {
            //InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var showMasterPasswordDialog = new DecryptionKeyDialog();
            var dialogResult = showMasterPasswordDialog.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value && !string.IsNullOrWhiteSpace(showMasterPasswordDialog.txtPassword.Password))
            {
                var decryptionKey = showMasterPasswordDialog.txtPassword.Password;

                //we decrypt the password file

            }
        }
    }
}
