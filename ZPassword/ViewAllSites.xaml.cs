using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZPassword;

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

        private const string passwordsFile = "simpleStore.csv";
        private Dictionary<string, string> AllPasswords = new Dictionary<string, string>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowAllSites();
            //var showMasterPasswordDialog = new DecryptionKeyDialog();
            //var dialogResult = showMasterPasswordDialog.ShowDialog();
            //if (dialogResult.HasValue && dialogResult.Value && !string.IsNullOrWhiteSpace(showMasterPasswordDialog.txtPassword.Password))
            //{
            //    var decryptionKey = showMasterPasswordDialog.txtPassword.Password;

            //    //we decrypt the password file

            //}
        }

        private void ShowAllSites()
        {
            wpCurrentSites.Children.Clear();
            var sitePasswords = File.ReadAllLines(passwordsFile);

            AllPasswords["AddNewPassword"] = "";
            var addNewSiteButton = GetButton("Add New Password");
            addNewSiteButton.Click += ShowAddNewPasswordViewer;
            wpCurrentSites.Children.Add(addNewSiteButton);

            foreach (var sitePassword in sitePasswords)
            {
                var sitePasswordParts = sitePassword.Split(',');
                if (sitePasswordParts.Length != 2)
                    continue;

                var siteName = sitePasswordParts[0];
                var hashedPassword = sitePasswordParts[1];

                AllPasswords[siteName] = hashedPassword;
                AddButton(siteName, hashedPassword);
            }
        }

        void SaveEdits(Dictionary<string, string> allPasswords)
        {
            File.WriteAllLines(passwordsFile, (from password in allPasswords select password.Key + "," + password.Value));
        }

        private void AddButton(string siteName, string hashedPassword)
        {
            var button = GetButton(siteName);
            button.Click += ShowPassword;
            wpCurrentSites.Children.Add(button);
        }

        private Button GetButton(string siteName)
        {
            var cleanSiteName = Regex.Replace(siteName, "[^0-9a-zA-Z]", string.Empty);
            return new Button { Name = "btn" + cleanSiteName, Content = siteName, Height = 40, Width = 150, Margin = new Thickness() { Left = 10, Bottom = 10, Right = 0, Top = 0 } };
        }


        private void ShowAddNewPasswordViewer(object sender, RoutedEventArgs e)
        {
            var asButton = sender as Button;
            if (asButton == null)
                return;

            var viewer = new AddPassword() { ShowPasswordViewer = ShowPasswordViewer };
            var dialogResult = viewer.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
            {
                //we save the new password
                if (!string.IsNullOrWhiteSpace(viewer.txtPassword.Password) && !string.IsNullOrWhiteSpace(viewer.txtSiteName.Text))
                {
                    var newPassword = viewer.txtPassword.Password;
                    var siteName = viewer.txtSiteName.Text;
                    AllPasswords[siteName] = newPassword;
                    SaveEdits(AllPasswords);
                    ShowAllSites();
                }
            }
        }


        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            var asButton = sender as Button;
            if (asButton == null)
                return;

            var siteName = asButton.Content.ToString();
            ShowPasswordViewer(siteName);
        }

        private void ShowPasswordViewer(string siteName)
        {
            var hashedPassword = string.Empty;
            if (!AllPasswords.TryGetValue(siteName, out hashedPassword))
            {
                return;
            }

            var viewer = new PasswordViewer {txtPassword = {Text = hashedPassword}, SiteName = siteName};
            var dialogResult = viewer.ShowDialog();
            if (dialogResult.HasValue && dialogResult.Value)
            {
                //we save the new password
                var newPassword = viewer.txtPassword.Text;
                AllPasswords[siteName] = newPassword;
            }
        }
    }
}
