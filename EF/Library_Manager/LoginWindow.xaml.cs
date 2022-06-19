using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Library_Manager.Repository.Models;
namespace Library_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private Library_Manager.HomeWindow homeWindow = null!;
        private string err = null!;
        public LoginWindow()
        {
            InitializeComponent();
            imgHCMUTE.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/dai-hoc-su-pham-tphcm.png")));
        }

        private void txtUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            txtUsername.Clear();
            if (this.txtPassword.Password == "")
                this.txtPassword.Password = "      ";
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPassword.Clear();
            if (this.txtUsername.Text == "")
                this.txtUsername.Text = "Tên tài khoản";
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // btn login chính
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool res = false;

            int count = AuthenticationSystem.Search(txtUsername.Text.Trim(), txtPassword.Password.Trim()).Count;
            if (count > 0)
                res = true;

            if (res)
            {
                this.Hide();
                homeWindow = new Library_Manager.HomeWindow(this);
                homeWindow.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại", "", MessageBoxButton.OK);
            }
        }

        // btn chuyển qua trang change password
        private void btnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            this.frmChangePassword.Visibility = Visibility.Visible;
            this.frmLogin.Visibility = Visibility.Hidden;
        }

        // btn change password chính
        private void btnLogin_Change_Click(object sender, RoutedEventArgs e)
        {
            string username = this.txtUsername_Change.Text.Trim();
            string password = this.txtPassword_Change.Password.Trim();
            string re_password = this.txtRePassword_Change.Password.Trim();

            bool res = false;

            int count = AuthenticationSystem.Search(username, password).Count;
            if (count > 0)
                res = true;
            else
                MessageBox.Show("Tài khoản, mật khẩu chưa chính xác");

            if (res)
            {
                try
                {
                    AuthenticationSystem authentication = new AuthenticationSystem()
                    {
                        StaffId = AuthenticationSystem.getAuthentication(username).StaffId,
                        Username = username,
                        PassWord = re_password,
                    };
                    authentication.Update();
                    MessageBox.Show("Đổi mật khẩu thành công");
                }
                catch
                {
                    MessageBox.Show("Đổi mật khẩu thất bại", "", MessageBoxButton.OK);
                }
            }
        }

        // btn chuyển qua trang login
        private void btnChangePassword_Change_Click(object sender, RoutedEventArgs e)
        {
            this.frmChangePassword.Visibility = Visibility.Hidden;
            this.frmLogin.Visibility = Visibility.Visible;
        }

        private void txtUsername_Change_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txtUsername_Change.Clear();
            if (this.txtPassword_Change.Password == "")
                this.txtPassword_Change.Password = "      ";
            if (this.txtRePassword_Change.Password == "")
                this.txtRePassword_Change.Password = "      ";
        }

        private void txtPassword_Change_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txtPassword_Change.Clear();
            if (this.txtUsername_Change.Text == "")
                this.txtUsername_Change.Text = "Tên tài khoản";
            if (this.txtRePassword_Change.Password == "")
                this.txtRePassword_Change.Password = "      ";
        }

        private void txtRePassword_Change_GotFocus(object sender, RoutedEventArgs e)
        {
            this.txtRePassword_Change.Clear();
            if (this.txtUsername_Change.Text == "")
                this.txtUsername_Change.Text = "Tên tài khoản";
            if (this.txtPassword_Change.Password == "")
                this.txtPassword_Change.Password = "      ";
        }
    }
}
