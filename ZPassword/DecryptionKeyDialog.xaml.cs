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

namespace Z10PasswordVault
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class DecryptionKeyDialog : Window
    {
        public DecryptionKeyDialog()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Return)
            {
                DialogResult = true;
            }
        }

        //public string 
    }
}
