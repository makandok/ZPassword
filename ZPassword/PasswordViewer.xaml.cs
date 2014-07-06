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
using System.Windows.Shapes;

namespace ZPassword
{
    /// <summary>
    /// Interaction logic for PasswordViewer1.xaml
    /// </summary>
    public partial class PasswordViewer : Window
    {
        public PasswordViewer()
        {
            InitializeComponent();
        }

        private void btnSaveChages_Clicked(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                DialogResult = true;
            }
        }

        public string SiteName { get; set; }
    }
}
