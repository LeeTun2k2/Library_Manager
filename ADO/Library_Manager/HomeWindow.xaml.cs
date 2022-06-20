using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System;
using Library_Manager.BSLayer;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace Library_Manager
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        private LoginWindow loginWindow = null!;
        private string hover_color = "#f7f7f7";

        // Btn switch tab
        private Button btnCaptured = null!;
        private Grid grvTab = null!;
        private DispatcherTimer timer = null!;

        public HomeWindow(LoginWindow loginWindow)
        {
            InitializeComponent();
            this.load_firstTab();
            this.loginWindow = loginWindow;
            this.loadTimer();
        }






        #region timer
        private void loadTimer()
        {
            this.timer_Tick(null!, null!);
            timer = new DispatcherTimer();
            timer.Interval = System.TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick!;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string hours = "";
            hours += (DateTime.Now.Hour < 10) ? $"0{DateTime.Now.Hour}:" : $"{DateTime.Now.Hour}:";
            hours += (DateTime.Now.Minute < 10) ? $"0{DateTime.Now.Minute}" : $"{DateTime.Now.Minute}";
            lbHours.Content = hours;
            lbDate.Content = $"{DateTime.Now.DayOfWeek}, {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}";
        }

        #endregion





        #region logic
        private void load_firstTab()
        {
            this.btnBook.Background = (SolidColorBrush)new BrushConverter().ConvertFrom(hover_color);
            this.btnCaptured = this.btnBook;
            this.grvTab = this.grvBook;
            TB.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Sach_TB2.png"))));
            GDBorder.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/GD_Sách.png"))));
            tab.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Sach.png"))));


            this.loadDataBook();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void dgvTab_Capture_Action(Button btn, Grid grv)
        {
            this.btnCaptured.Background = Brushes.Transparent;
            btn.Background = (SolidColorBrush)new BrushConverter().ConvertFrom(hover_color);
            this.btnCaptured = btn;


            this.grvTab.Visibility = Visibility.Hidden;
            grv.Visibility = Visibility.Visible;
            this.grvTab = grv;
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            TB.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Sach_TB2.png"))));
            GDBorder.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/GD_Sách.png"))));
            tab.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Sach.png"))));
            this.dgvTab_Capture_Action(btnBook, grvBook);
            this.loadDataBook();
        }

        private void btnAuthor_Click(object sender, RoutedEventArgs e)
        {
            TB.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/TBN.png"))));
            GDBorder.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Tacgia.png"))));
            tab.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/t.png"))));
   
            this.dgvTab_Capture_Action(btnAuthor, grvAuthor);
            this.loadDataAuthor();
        }

        private void btnPublisher_Click(object sender, RoutedEventArgs e)
        {
            TB.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Nhaxb_tren.png"))));
            GDBorder.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Nhaxbgd.png"))));
            tab.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Nhaxb_ngang.png"))));
            this.dgvTab_Capture_Action(btnPublisher, grvPublisher);
            this.loadDataPublisher();
        }

        private void btnReader_Click(object sender, RoutedEventArgs e)
        {
            TB.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/docgia_tren.png"))));
            GDBorder.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Docgiagd.png"))));
            tab.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/docgia_ngang.png"))));
            this.dgvTab_Capture_Action(btnReader, grvReader);
            this.loadDataReader();
        }

        private void btnReverseReturn_Click(object sender, RoutedEventArgs e)
        {
            TB.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/muon_tren.png"))));
            GDBorder.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Muongd.png"))));
            tab.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/muon_ngang.png"))));
            this.dgvTab_Capture_Action(btnReverseReturn, grvReserveReturn);
            this.loadDataReverseReturn();
        }

        private void btnStaff_Click(object sender, RoutedEventArgs e)
        {
            //this.lbHeader.Content = "QUẢN LÝ NHÂN VIÊN".ToUpper();
            TB.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Nhanvien_tren.png"))));
            GDBorder.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Nhanviengd.png"))));
            tab.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/nhanvien_ngang.png"))));
            this.dgvTab_Capture_Action(btnStaff, grvStaff);
            this.loadDataStaff();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            TB.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Nhanvien_tren.png"))));
            GDBorder.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/Nhanviengd.png"))));
            tab.Background = new ImageBrush(new BitmapImage(new Uri(System.IO.Path.GetFullPath("./assets/img/72ppi/nhanvien_ngang.png"))));
            this.dgvTab_Capture_Action(btnReport, grvHelp);

        }


        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.loginWindow.Show();
        }

        #endregion





        #region loadData
        private string err = null!;
        private DataTable dataTable = null!;
        private BLBook bLBook = new BLBook();
        private BLAuthor bLAuthor = new BLAuthor();
        private BLPublisher bLPublisher = new BLPublisher();
        private BLReader bBLReader = new BLReader();
        private BLReverse_Return bBLReverseReturn = new BLReverse_Return();
        private BLStaff bBLStaff = new BLStaff();
        private void loadDataBook()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bLBook.Get();
                dataTable = ds.Tables[0];
                dgBook.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgBook_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRow row = (dgBook.SelectedItem as DataRowView)?.Row!;
                if (row != null)
                {
                    txtBookID.Text = row["Book_id"].ToString()!.Trim();
                    txtBookTitle.Text = row["Title"].ToString()!.Trim();
                    txtBookCategory.Text = row["Category"].ToString()!.Trim();
                    txtBookAuthor.Text = row["Author_id"].ToString()!.Trim();
                    txtBookPublisher.Text = row["Publisher_id"].ToString()!.Trim();
                    txtYearOfPublication.Text = row["YearOfPublication"].ToString()!.Trim();
                    txtBookPrice.Text = row["Price"].ToString()!.Trim();
                    txtBookQuantity.Text = row["Quantity"].ToString()!.Trim();
                }
            }
            catch
            {

            }
        }


        private void dgAuthor_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRow row = (dgAuthor.SelectedItem as DataRowView)?.Row!;
                if (row != null)
                {
                    txtAuthorID.Text = row["Author_id"].ToString()!.Trim();
                    txtAuthorName.Text = row["Author_name"].ToString()!.Trim();
                }
            }
            catch
            {

            }
        }

        private void dgPublisher_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRow row = (dgPublisher.SelectedItem as DataRowView)?.Row!;
                if (row != null)
                {
                    txtPublisherID.Text = row["Publisher_id"].ToString()!.Trim();
                    txtPublisherName.Text = row["Publisher_name"].ToString()!.Trim();
                    txtPublisherEmail.Text = row["Email"].ToString()!.Trim();
                    txtPublisherPhone.Text = row["Phone_no"].ToString()!.Trim();
                    txtPublisherAddress.Text = row["Addr"].ToString()!.Trim();
                }
            }
            catch
            {

            }
        }

        private void dgReader_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRow row = (dgReader.SelectedItem as DataRowView)?.Row!;
                if (row != null)
                {
                    txtReaderID.Text = row["Reader_id"].ToString()!.Trim();
                    txtReaderName.Text = row["Reader_name"].ToString()!.Trim();
                    txtReaderBirthDay.Text = row["Birthday"].ToString()!.Trim();
                    txtReaderSex.Text = row["Sex"].ToString()!.Trim();
                    txtReaderEmail.Text = row["Email"].ToString()!.Trim();
                    txtReaderPhone.Text = row["Phone_no"].ToString()!.Trim();
                    txtReaderAddress.Text = row["Addr"].ToString()!.Trim();
                }
            }
            catch
            {

            }
        }

        private void dgReserveReturn_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRow row = (dgReserveReturn.SelectedItem as DataRowView)?.Row!;
                if (row != null)
                {
                    txtReg_ID.Text = row["Reg_id"].ToString()!.Trim();
                    txtReg_ReaderID.Text = row["Reader_id"].ToString()!.Trim();
                    txtReg_BookID.Text = row["Book_id"].ToString()!.Trim();
                    txtReg_ReserveDate.Text = row["ReserveDate"].ToString()!.Trim();
                    txtReg_DueDate.Text = row["DueDate"].ToString()!.Trim();
                    txtReturnDate.Text = row["ReturnDate"].ToString()!.Trim();
                    txtReg_ReserveStaffID.Text = row["ReserveStaff_id"].ToString()!.Trim();
                    txtReg_ReturnStaffID.Text = row["ReturnStaff_id"].ToString()!.Trim();
                }
            }
            catch
            {

            }
        }

        private void dgStaff_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                DataRow row = (dgStaff.SelectedItem as DataRowView)?.Row!;
                if (row != null)
                {
                    txtStaffID.Text = row["Staff_id"].ToString()!.Trim();
                    txtStaffName.Text = row["Staff_name"].ToString()!.Trim();
                    txtStaffBirthday.Text = row["Birthday"].ToString()!.Trim();
                    txtStaffSex.Text = row["Sex"].ToString()!.Trim();
                    txtStaffEmail.Text = row["Email"].ToString()!.Trim();
                    txtStaffPhone.Text = row["Phone_no"].ToString()!.Trim();
                    txtStaffAddress.Text = row["Addr"].ToString()!.Trim();
                    txtStaffStartDate.Text = row["StartDate"].ToString()!.Trim();
                    txtStaffSalary.Text = row["Salary"].ToString()!.Trim();

                }
            }
            catch
            {

            }
        }

        private void loadDataAuthor()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bLAuthor.Get();
                dataTable = ds.Tables[0];
                dgAuthor.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadDataPublisher()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bLPublisher.Get();
                dataTable = ds.Tables[0];
                dgPublisher.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadDataReader()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bBLReader.Get();
                dataTable = ds.Tables[0];
                dgReader.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadDataReverseReturn()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bBLReverseReturn.Get();
                dataTable = ds.Tables[0];
                dgReserveReturn.ItemsSource = ds.Tables[0].DefaultView;

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadDataStaff()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bBLStaff.Get();
                dataTable = ds.Tables[0];
                dgStaff.ItemsSource = ds.Tables[0].DefaultView;


            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion







        #region add data
        private void addBook()
        {
            try
            {
                if (!bLBook.Add(txtBookID.Text.Trim(), 
                    txtBookTitle.Text.Trim(), 
                    txtBookCategory.Text.Trim(), 
                    txtBookAuthor.Text.Trim(), 
                    txtBookPublisher.Text.Trim(), 
                    txtYearOfPublication.Text.Trim(), 
                    txtBookPrice.Text.Trim(), 
                    txtBookQuantity.Text.Trim(), ref err))
                    MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                loadDataBook();
            }
            catch
            {
                
            }

        }
        private void addAuthor()
        {
            try
            {
                if (bLAuthor.Add(txtAuthorID.Text.Trim(), 
                    txtAuthorName.Text.Trim(),
                    ref err))
                    MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                loadDataAuthor();
            }
            catch
            {
            }

        }
        private void addPublisher()
        {
            try
            {
                 if (bLPublisher.Add(txtPublisherID.Text.Trim(),
                     txtPublisherName.Text.Trim(),
                     txtPublisherEmail.Text.Trim(),
                     txtPublisherPhone.Text.Trim(),
                     txtPublisherAddress.Text.Trim(),
                     ref err))
                    MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                 else
                    MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                loadDataPublisher();
            }
            catch
            {
                
            }

        }

        private void addReader()
        {
            try
            {
                if (bBLReader.Add(txtReaderID.Text.Trim(),
                    txtReaderName.Text.Trim(),
                    txtReaderBirthDay.Text.Trim(),
                    txtReaderSex.Text.Trim(),
                    txtReaderEmail.Text.Trim(),
                    txtReaderPhone.Text.Trim(),
                    txtReaderAddress.Text.Trim(),
                    ref err))
                    MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                loadDataReader();
                
            }
            catch
            {
                
            }

        }

        private void addReverseReturn()
        {
            try
            {
                if (bBLReverseReturn.Add(txtReg_ID.Text.Trim(),
                    txtReg_ReaderID.Text.Trim(),
                    txtReg_BookID.Text.Trim(),
                    txtReg_ReserveDate.Text.Trim(),
                    txtReg_DueDate.Text.Trim(),
                    txtReturnDate.Text.Trim(),
                    txtReg_ReserveStaffID.Text.Trim(),
                    txtReg_ReturnStaffID.Text.Trim(),
                    ref err))
                    MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);

                loadDataReverseReturn();
            }
            catch
            {
            }

        }
        private void addStaff()
        {
            try
            {
                if (bBLStaff.Add(txtStaffID.Text.Trim(),
                    txtStaffName.Text.Trim(),
                    txtStaffBirthday.Text.Trim(),
                    txtStaffSex.Text.Trim(),
                    txtStaffEmail.Text.Trim(),
                    txtStaffPhone.Text.Trim(),
                    txtStaffAddress.Text.Trim(),
                    txtStaffStartDate.Text.Trim(),
                    txtStaffSalary.Text.Trim(),
                    ref err))
                    MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                loadDataStaff();
            }
            catch
            {
            }

        }

        #endregion







        #region update data
        private bool checkID(string id)
        {
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (id == dataTable.Rows[i][0].ToString()!.Trim())
                    return true;
            }
            return false;
        }

        private void updateBook()
        {
            if (checkID(txtBookID.Text.Trim()))
            {
                try
                {
                    if (bLBook.Update(txtBookID.Text.Trim(),
                        txtBookTitle.Text.Trim(),
                        txtBookCategory.Text.Trim(),
                        txtBookAuthor.Text.Trim(),
                        txtBookPublisher.Text.Trim(),
                        txtYearOfPublication.Text.Trim(),
                        txtBookPrice.Text.Trim(),
                        txtBookQuantity.Text.Trim(), ref err))
                        MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    loadDataBook();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        private void updateAuthor()
        {
            if (checkID(txtAuthorID.Text.Trim()))
            {
                try
                {
                    if (bLAuthor.Update(txtAuthorID.Text.Trim(), txtAuthorName.Text.Trim(), ref err))
                        MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    loadDataAuthor();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void updatePublisher()
        {

            if (checkID(txtPublisherID.Text.Trim()))
            {
                try
                {
                    if (bLPublisher.Update(txtPublisherID.Text.Trim(),
                        txtPublisherName.Text.Trim(),
                        txtPublisherEmail.Text.Trim(),
                        txtPublisherPhone.Text.Trim(),
                        txtPublisherAddress.Text.Trim(),
                        ref err))
                        MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    loadDataPublisher();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void updateReader()
        {
            if (checkID(txtReaderID.Text.Trim()))
            {
                try
                {
                    if (bBLReader.Update(txtReaderID.Text.Trim(),
                        txtReaderName.Text.Trim(),
                        txtReaderBirthDay.Text.Trim(),
                        txtReaderSex.Text.Trim(),
                        txtReaderEmail.Text.Trim(),
                        txtReaderEmail.Text.Trim(),
                        txtReaderAddress.Text.Trim(),
                        ref err))
                        MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    loadDataReader();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            

        }

        private void updateReverseReturn()
        {
            if (checkID(txtReg_ID.Text.Trim()))
            {
                try
                {
                    if (bBLReverseReturn.Update(txtReg_ID.Text.Trim(),
                        txtReg_ReaderID.Text.Trim(),
                        txtReg_BookID.Text.Trim(),
                        txtReg_ReserveDate.Text.Trim(),
                        txtReg_DueDate.Text.Trim(),
                        txtReturnDate.Text.Trim(),
                        txtReg_ReserveStaffID.Text.Trim(),
                        txtReg_ReturnStaffID.Text.Trim(),
                        ref err))
                        MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    loadDataReverseReturn();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            

        }

        private void updateStaff()
        {
            if (checkID(txtStaffID.Text.Trim()))
            {
                try
                {
                    if (bBLStaff.Update(
                        txtStaffID.Text.Trim(),
                        txtStaffName.Text.Trim(),
                        txtStaffBirthday.Text.Trim(),
                        txtStaffSex.Text.Trim(),
                        txtStaffEmail.Text.Trim(),
                        txtStaffPhone.Text.Trim(),
                        txtStaffAddress.Text.Trim(),
                        txtStaffStartDate.Text.Trim(),
                        txtStaffSalary.Text.Trim(),
                        ref err))
                        MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    loadDataStaff();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }


        #endregion









        #region delete
        private void deleteBook()
        {
            if (checkID(txtBookID.Text.Trim()))
            {
                MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    try
                    {
                        bLBook.Delete(txtBookID.Text, ref err);
                        loadDataBook();
                    }
                    catch
                    {
                        MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void deleteAuthor()
        {
            if (checkID(txtAuthorID.Text.Trim()))
            {
                MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    try
                    {
                        bLAuthor.Delete(txtAuthorID.Text.Trim(), ref err);
                        loadDataAuthor();
                    }
                    catch
                    {
                        MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }
        private void deletePublisher()
        {
            if (checkID(txtPublisherID.Text.Trim()))
            {
                MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    try
                    {
                        bLPublisher.Delete(txtPublisherID.Text, ref err);
                        loadDataPublisher();
                    }
                    catch
                    {
                        MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void deleteReader()
        {
            if (checkID(txtReaderID.Text.Trim()))
            {
                MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    try
                    {
                        bBLReader.Delete(txtReaderID.Text, ref err);
                        loadDataReader();
                    }
                    catch
                    {
                        MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
        private void deleteReverseReturn()
        {
            if (checkID(txtReaderID.Text.Trim()))
            {
                MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    try
                    {
                        bBLReverseReturn.Delete(txtReg_ID.Text, ref err);
                        loadDataReverseReturn();
                    }
                    catch
                    {
                        MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }
        private void deleteStaff()
        {
            if (checkID(txtStaffID.Text.Trim()))
            {
                MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (res == MessageBoxResult.Yes)
                {
                    try
                    {
                        bBLStaff.Delete(txtStaffID.Text, ref err);
                        loadDataStaff();
                    }
                    catch
                    {
                        MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("ID không tồn tại", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        #endregion






        #region search
        private void searchBook()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bLBook.Search(
                    txtBookID.Text.Trim(), 
                    txtBookTitle.Text.Trim(),
                    txtBookCategory.Text.Trim(), 
                    txtBookAuthor.Text.Trim(),
                    txtBookPublisher.Text.Trim(), 
                    txtYearOfPublication.Text.Trim(),
                    txtBookPrice.Text.Trim(), 
                    txtBookQuantity.Text.Trim(), ref err);
                dataTable = ds.Tables[0];
                dgBook.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch
            {

            }
        }
        
        private void searchAuthor()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bLAuthor.Search(
                    txtAuthorID.Text.Trim(), 
                    txtAuthorName.Text.Trim(),
                    ref err);
                dataTable = ds.Tables[0];
                dgAuthor.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch
            {

            }
        }


        private void searchPublisher()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bLPublisher.Search(
                    txtPublisherID.Text.Trim(),
                    txtPublisherName.Text.Trim(),
                    txtPublisherEmail.Text.Trim(),
                    txtPublisherPhone.Text.Trim(),
                    txtPublisherAddress.Text.Trim(),
                    ref err);
                dataTable = ds.Tables[0];
                dgPublisher.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch
            {

            }
        }


        private void searchReader()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bBLReader.Search(
                    txtReaderID.Text.Trim(),
                    txtReaderName.Text.Trim(),
                    txtReaderBirthDay.Text.Trim(),
                    txtReaderSex.Text.Trim(),
                    txtReaderEmail.Text.Trim(),
                    txtReaderPhone.Text.Trim(),
                    txtReaderAddress.Text.Trim(),
                    ref err);
                dataTable = ds.Tables[0];
                dgReader.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch
            {

            }
        }


        private void searchReverseReturn()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bBLReverseReturn.Search(
                    txtReg_ID.Text.Trim(),
                    txtReg_ReaderID.Text.Trim(),
                    txtReg_BookID.Text.Trim(),
                    txtReg_ReserveDate.Text.Trim(),
                    txtReg_DueDate.Text.Trim(),
                    txtReturnDate.Text.Trim(),
                    txtReg_ReserveStaffID.Text.Trim(),
                    txtReg_ReturnStaffID.Text.Trim(),
                    ref err);
                dataTable = ds.Tables[0];
                dgReserveReturn.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch
            {

            }
        }

        private void searchStaff()
        {
            try
            {
                dataTable = new DataTable();
                dataTable.Clear();
                DataSet ds = bBLStaff.Search(
                    txtStaffID.Text.Trim(),
                    txtStaffName.Text.Trim(),
                    txtStaffBirthday.Text.Trim(),
                    txtStaffSex.Text.Trim(),
                    txtStaffEmail.Text.Trim(),
                    txtStaffPhone.Text.Trim(),
                    txtStaffAddress.Text.Trim(),
                    txtStaffStartDate.Text.Trim(),
                    txtStaffSalary.Text.Trim(), 

                    ref err);
                dataTable = ds.Tables[0];
                dgStaff.ItemsSource = ds.Tables[0].DefaultView;
            }
            catch
            {

            }
        }
        #endregion







        #region clear
        private void clearBook()
        {
            txtBookID.Clear();
            txtBookTitle.Clear();
            txtBookCategory.Clear();
            txtBookAuthor.Clear();
            txtBookPublisher.Clear();
            txtYearOfPublication.Clear();
            txtBookPrice.Clear();
            txtBookQuantity.Clear();
        }

        private void clearAuthor()
        {
            txtAuthorID.Clear();
            txtAuthorName.Clear();
        }

        private void clearPublisher()
        {
            txtPublisherID.Clear();
                     txtPublisherName.Clear();
                     txtPublisherEmail.Clear();
                     txtPublisherPhone.Clear();
                     txtPublisherAddress.Clear();
        }

        private void clearReader()
        {
            txtReaderID.Clear();
                    txtReaderName.Clear();
                    txtReaderBirthDay.Clear();
                    txtReaderSex.Clear();
                    txtReaderEmail.Clear();
                    txtReaderPhone.Clear();
                    txtReaderAddress.Clear();
        }

        private void clearReverseReturn()
        {
            txtReg_ID.Clear();
                    txtReg_ReaderID.Clear();
                    txtReg_BookID.Clear();
                    txtReg_ReserveDate.Clear();
                    txtReg_DueDate.Clear();
                    txtReturnDate.Clear();
                    txtReg_ReserveStaffID.Clear();
                    txtReg_ReturnStaffID.Clear();
        }

        private void clearStaff()
        {
            txtStaffID.Clear();
                    txtStaffName.Clear();
                    txtStaffBirthday.Clear();
                    txtStaffSex.Clear();
                    txtStaffEmail.Clear();
                    txtStaffPhone.Clear();
                    txtStaffAddress.Clear();
            txtStaffSalary.Clear();
            txtStaffStartDate.Clear();
        }


        #endregion


        #region event add, update, delete
        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            if (grvBook.Visibility == Visibility.Visible)
                this.loadDataBook();
            else if (grvAuthor.Visibility == Visibility.Visible)
                this.loadDataAuthor();
            else if (grvPublisher.Visibility == Visibility.Visible)
                this.loadDataPublisher();
            else if (grvReader.Visibility == Visibility.Visible)
                this.loadDataReader();
            else if (grvReserveReturn.Visibility == Visibility.Visible)
                this.loadDataReverseReturn();
            else if (grvStaff.Visibility == Visibility.Visible)
                this.loadDataStaff();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (grvBook.Visibility == Visibility.Visible)
                this.addBook();
            else if (grvAuthor.Visibility == Visibility.Visible)
                this.addAuthor();
            else if (grvPublisher.Visibility == Visibility.Visible)
                this.addPublisher();
            else if (grvReader.Visibility == Visibility.Visible)
                this.addReader();
            else if (grvReserveReturn.Visibility == Visibility.Visible)
                this.addReverseReturn();
            else if (grvStaff.Visibility == Visibility.Visible)
                this.addStaff();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            if (grvBook.Visibility == Visibility.Visible)
                this.updateBook();
            else if (grvAuthor.Visibility == Visibility.Visible)
                this.updateAuthor();
            else if (grvPublisher.Visibility == Visibility.Visible)
                this.updatePublisher();
            else if (grvReader.Visibility == Visibility.Visible)
                this.updateReader();
            else if (grvReserveReturn.Visibility == Visibility.Visible)
                this.updateReverseReturn();
            else if (grvStaff.Visibility == Visibility.Visible)
                this.updateStaff();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (grvBook.Visibility == Visibility.Visible)
                this.deleteBook();
            else if (grvAuthor.Visibility == Visibility.Visible)
                this.deleteAuthor();
            else if (grvPublisher.Visibility == Visibility.Visible)
                this.deletePublisher();
            else if (grvReader.Visibility == Visibility.Visible)
                this.deleteReader();
            else if (grvReserveReturn.Visibility == Visibility.Visible)
                this.deleteReverseReturn();
            else if (grvStaff.Visibility == Visibility.Visible)
                this.deleteStaff();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (grvBook.Visibility == Visibility.Visible)
                this.clearBook();
            else if (grvAuthor.Visibility == Visibility.Visible)
                this.clearAuthor();
            else if (grvPublisher.Visibility == Visibility.Visible)
                this.clearPublisher();
            else if (grvReader.Visibility == Visibility.Visible)
                this.clearReader();
            else if (grvReserveReturn.Visibility == Visibility.Visible)
                this.clearReverseReturn();
            else if (grvStaff.Visibility == Visibility.Visible)
                this.clearStaff();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
                        if (grvBook.Visibility == Visibility.Visible)
                this.searchBook();
            else if (grvAuthor.Visibility == Visibility.Visible)
                this.searchAuthor();
            else if (grvPublisher.Visibility == Visibility.Visible)
                this.searchPublisher();
            else if (grvReader.Visibility == Visibility.Visible)
                this.searchReader();
            else if (grvReserveReturn.Visibility == Visibility.Visible)
                this.searchReverseReturn();
            else if (grvStaff.Visibility == Visibility.Visible)
                this.searchStaff();
        }


        #endregion


    }
}
