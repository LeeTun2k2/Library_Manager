using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using Library_Manager.Repository.Models;

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
        private List<Book> books = new List<Book>(Book.GetAll());
        private List<Author> authors = new List<Author>(Author.GetAll());
        private List<Publisher> publishers = new List<Publisher>(Publisher.GetAll());
        private List<Reader> readers = new List<Reader>(Reader.GetAll());
        private List<ReverseReturn> reverseReturns = new List<ReverseReturn>(ReverseReturn.GetAll());
        private List<staff> staffs = new List<staff>(staff.GetAll());
        private void loadDataBook()
        {
            try
            {
                books = new List<Book>(Book.GetAll());
                dgBook.ItemsSource = books;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgBook_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                Book book = (Book)dgBook.SelectedItem;

                if (book != null)
                {
                    txtBookID.Text = book.BookId.Trim();
                    txtBookTitle.Text = book.Title.Trim();
                    txtBookAuthor.Text = book.AuthorId.Trim();
                    txtBookPublisher.Text = book.PublisherId.Trim();
                    txtYearOfPublication.Text = book.YearOfPublication.ToString().Trim();
                    txtBookCategory.Text = book.Category.Trim();
                    txtBookPrice.Text = book.Price.ToString().Trim();
                    txtBookQuantity.Text = book.Quantity.ToString().Trim();
                }
            }
            catch
            {
                MessageBox.Show("Err");
            }
        }

        private void dgAuthor_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                Author author = (Author)dgAuthor.SelectedItem;

                if (author != null)
                {
                    txtAuthorID.Text = author.AuthorId.Trim().Trim();
                    txtAuthorName.Text = author.AuthorName.Trim().Trim();
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
                Publisher publisher = (Publisher)dgPublisher.SelectedItem;

                if (publisher != null)
                {
                    txtPublisherID.Text = publisher.PublisherId.Trim();
                    txtPublisherName.Text = publisher.PublisherName.Trim();
                    txtPublisherPhone.Text = publisher.PhoneNo.Trim();
                    txtPublisherEmail.Text = publisher.Email.Trim();
                    txtPublisherAddress.Text = publisher.Addr.Trim();
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
                Reader reader = (Reader)dgReader.SelectedItem;
                if (reader != null)
                {
                    txtReaderID.Text = reader.ReaderId.Trim();
                    txtReaderName.Text = reader.ReaderName.Trim();
                    txtReaderBirthDay.Text = reader.Birthday.ToShortDateString();
                    txtReaderSex.Text = reader.Sex.Trim();
                    txtReaderEmail.Text = reader.Email.Trim();
                    txtReaderPhone.Text = reader.PhoneNo.Trim();
                    txtReaderAddress.Text = reader.Addr.Trim();
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
                ReverseReturn reverseReturn = (ReverseReturn)dgReserveReturn.SelectedItem;
                if (reverseReturn != null)
                {
                    txtReg_ID.Text = reverseReturn.RegId.Trim();
                    txtReg_ReaderID.Text = reverseReturn.ReaderId.Trim();
                    txtReg_BookID.Text = reverseReturn.BookId.Trim();
                    txtReg_ReserveDate.Text = reverseReturn.ReserveDate.ToShortDateString();
                    txtReg_DueDate.Text = reverseReturn.DueDate.ToShortDateString();
                    txtReturnDate.Text = reverseReturn.ReturnDate.ToShortDateString();
                    txtReg_ReserveStaffID.Text = reverseReturn.ReserveStaffId.Trim();
                    txtReg_ReturnStaffID.Text = reverseReturn.ReturnStaffId.Trim();
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
                staff staff_ = (staff)dgStaff.SelectedItem;
                if (staff_ != null)
                {
                    txtStaffID.Text = staff_.StaffId.Trim();
                    txtStaffName.Text = staff_.StaffName.Trim();
                    txtStaffBirthday.Text = staff_.Birthday.ToShortDateString();
                    txtStaffSex.Text = staff_.Sex.Trim();
                    txtStaffEmail.Text = staff_.Email.Trim();
                    txtStaffPhone.Text = staff_.PhoneNo.Trim();
                    txtStaffAddress.Text = staff_.Addr.Trim();
                    txtStaffStartDate.Text = staff_.StartDate.ToShortDateString();
                    txtStaffSalary.Text = staff_.Salary.Trim();
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
                authors = new List<Author>(Author.GetAll());
                dgAuthor.ItemsSource = authors;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadDataPublisher()
        {
            try
            {
                publishers = new List<Publisher>(Publisher.GetAll());
                dgPublisher.ItemsSource = publishers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadDataReader()
        {
            try
            {
                readers = new List<Reader>(Reader.GetAll());
                dgReader.ItemsSource = readers;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadDataReverseReturn()
        {
            try
            {
                reverseReturns = new List<ReverseReturn>(ReverseReturn.GetAll());
                dgReserveReturn.ItemsSource = reverseReturns;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void loadDataStaff()
        {
            try
            {
                staffs = new List<staff>(staff.GetAll());
                dgStaff.ItemsSource = staffs;
            }
            catch (Exception ex)
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
                Book book = new Book(){
                    BookId = txtBookID.Text.Trim(),
                    Title = txtBookTitle.Text.Trim(),
                    Category = txtBookCategory.Text.Trim(),
                    AuthorId = txtBookAuthor.Text.Trim(),
                    PublisherId = txtBookPublisher.Text.Trim(),
                    YearOfPublication = int.Parse(txtYearOfPublication.Text.Trim()),
                    Price = txtBookPrice.Text.Trim(),
                    Quantity = int.Parse(txtBookQuantity.Text.Trim())
                };
                book.Add();
                loadDataBook();
                MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void addAuthor()
        {
            try
            {
                Author author = new Author()
                {
                    AuthorId = txtAuthorID.Text.Trim(),
                    AuthorName = txtAuthorName.Text.Trim()
                };
                author.Add();
                loadDataAuthor();
                MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void addPublisher()
        {
            if (txtPublisherEmail.Text.Contains('@'))
            {
                try
                {
                    Publisher publisher = new Publisher()
                    {
                        PublisherId = txtPublisherID.Text.Trim(),
                        PublisherName = txtPublisherName.Text.Trim(),
                        PhoneNo = txtPublisherPhone.Text.Trim(),
                        Addr = txtPublisherAddress.Text.Trim(),
                        Email = txtPublisherEmail.Text.Trim()
                    };
                    publisher.Add();
                    loadDataPublisher();
                    MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (txtPublisherEmail.Text != "") MessageBox.Show("Email không hợp lệ");
            }
            

        }

        private void addReader()
        {
            if (txtReaderEmail.Text.Contains('@'))
            {
                try
                {
                    Reader reader = new Reader() { 
                    ReaderId = txtReaderID.Text.Trim(),
                    ReaderName = txtReaderName.Text.Trim(),
                    Addr = txtReaderAddress.Text.Trim(),
                    Birthday = DateTime.Parse(txtReaderBirthDay.Text.Trim()).Date,
                    Email = txtReaderEmail.Text.Trim(),
                    PhoneNo = txtReaderPhone.Text.Trim(),
                    Sex = txtReaderSex.Text.Trim()
                    };
                    reader.Add();
                    loadDataReader();
                    MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if (txtPublisherEmail.Text != "") MessageBox.Show("Email không hợp lệ");
            }
        }

        private void addReverseReturn()
        {
            try
            {
                ReverseReturn reverseReturn = new ReverseReturn()
                {
                    RegId = txtReg_ID.Text.Trim(),
                    ReaderId = txtReg_ReaderID.Text.Trim(),
                    ReserveDate = DateTime.Parse(txtReg_ReserveDate.Text.Trim()).Date,
                    ReserveStaffId = txtReg_ReserveStaffID.Text.Trim(),
                    ReturnDate = DateTime.Parse(txtReturnDate.Text.Trim()).Date,
                    ReturnStaffId = txtReg_ReturnStaffID.Text.Trim(),
                    DueDate = DateTime.Parse(txtReg_DueDate.Text.Trim()).Date,
                    BookId = txtReg_BookID.Text.Trim()
                };
                reverseReturn.Add();
                loadDataReverseReturn();
                MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void addStaff()
        {
            if (txtStaffEmail.Text.Contains('@'))
            {
                try
                {
                    staff staff_ = new staff() { 
                    StaffId = txtStaffID.Text.Trim(),
                    StaffName = txtStaffName.Text.Trim(),
                    Addr = txtStaffAddress.Text.Trim(),
                    Birthday = DateTime.Parse(txtStaffBirthday.Text.Trim()),
                    Email = txtStaffEmail.Text.Trim(),
                    PhoneNo = txtStaffPhone.Text.Trim(),
                    Salary = txtStaffSalary.Text.Trim(),
                    Sex = txtStaffSex.Text.Trim(),
                    StartDate = DateTime.Parse(txtStaffStartDate.Text.Trim())
                    };
                    staff_.Add();
                    loadDataStaff();
                    MessageBox.Show("Thêm thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Thêm thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                if (txtPublisherEmail.Text != "") MessageBox.Show("Email không hợp lệ");
            }

}

        #endregion







        #region update data

        private void updateBook()
        {
            try
            {
                //int YearOfPublication;
                //int.TryParse(txtYearOfPublication.Text, out YearOfPublication);
                Book book = new Book()
                {
                    BookId = txtBookID.Text.Trim(),
                    Title = txtBookTitle.Text.Trim(),
                    Category = txtBookCategory.Text.Trim(),
                    AuthorId = txtBookAuthor.Text.Trim(),
                    PublisherId = txtBookPublisher.Text.Trim(),
                    YearOfPublication = int.Parse(txtYearOfPublication.Text.Trim()),
                    Price = txtBookPrice.Text.Trim(),
                    Quantity = int.Parse(txtBookQuantity.Text.Trim())
                };
                book.Update();
                MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void updateAuthor()
        {
            try
            {
                Author author = new Author()
                {
                    AuthorId = txtAuthorID.Text.Trim(),
                    AuthorName = txtAuthorName.Text.Trim()
                };
                author.Update();
                loadDataAuthor();
                MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void updatePublisher()
        {
            if (txtPublisherEmail.Text.Contains('@'))
            {
                try
                {
                    Publisher publisher = new Publisher()
                    {
                        PublisherId = txtPublisherID.Text.Trim(),
                        PublisherName = txtPublisherName.Text.Trim(),
                        PhoneNo = txtPublisherPhone.Text.Trim(),
                        Addr = txtPublisherAddress.Text.Trim(),
                        Email = txtPublisherEmail.Text.Trim()
                    };
                    publisher.Update();
                    loadDataPublisher();
                    MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                if (txtPublisherEmail.Text != "") MessageBox.Show("Email không hợp lệ");
        }

        private void updateReader()
        {
            if (txtReaderEmail.Text.Contains('@'))
            { 
                try
                {
                    Reader reader = new Reader()
                    {
                        ReaderId = txtReaderID.Text.Trim(),
                        ReaderName = txtReaderName.Text.Trim(),
                        Addr = txtReaderAddress.Text.Trim(),
                        Birthday = DateTime.Parse(txtReaderBirthDay.Text.Trim()).Date,
                        Email = txtReaderEmail.Text.Trim(),
                        PhoneNo = txtReaderPhone.Text.Trim(),
                        Sex = txtReaderSex.Text.Trim()
                    };
                    reader.Update();
                    loadDataReader();
                    MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                if (txtPublisherEmail.Text != "") MessageBox.Show("Email không hợp lệ");
        }

        private void updateReverseReturn()
        {
            try
            {
                ReverseReturn reverseReturn = new ReverseReturn()
                {
                    RegId = txtReg_ID.Text.Trim(),
                    ReaderId = txtReg_ReaderID.Text.Trim(),
                    ReserveDate = DateTime.Parse(txtReg_ReserveDate.Text.Trim()).Date,
                    ReserveStaffId = txtReg_ReserveStaffID.Text.Trim(),
                    ReturnDate = DateTime.Parse(txtReturnDate.Text.Trim()).Date,
                    ReturnStaffId = txtReg_ReturnStaffID.Text.Trim(),
                    DueDate = DateTime.Parse(txtReg_DueDate.Text.Trim()).Date,
                    BookId = txtReg_BookID.Text.Trim()
                };
                reverseReturn.Update();
                loadDataReverseReturn();
                MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void updateStaff()
        {
            if (txtStaffEmail.Text.Contains('@'))
            { 
                try
                {
                    staff staff_ = new staff()
                    {
                        StaffId = txtStaffID.Text.Trim(),
                        StaffName = txtStaffName.Text.Trim(),
                        Addr = txtStaffAddress.Text.Trim(),
                        Birthday = DateTime.Parse(txtStaffBirthday.Text.Trim()),
                        Email = txtStaffEmail.Text.Trim(),
                        PhoneNo = txtStaffPhone.Text.Trim(),
                        Salary = txtStaffSalary.Text.Trim(),
                        Sex = txtStaffSex.Text.Trim(),
                        StartDate = DateTime.Parse(txtStaffStartDate.Text.Trim()),

                    };
                    staff_.Update();
                    loadDataStaff();
                    MessageBox.Show("Cập nhật thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Cập nhật thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
                if (txtPublisherEmail.Text != "") MessageBox.Show("Email không hợp lệ");

        }


        #endregion









        #region delete
        private void deleteBook()
        {
            MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Book.Delete(txtBookID.Text.Trim());
                    loadDataBook();
                    MessageBox.Show("Xóa thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void deleteAuthor()
        {
            MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Author.Delete(txtAuthorID.Text.Trim());
                    loadDataAuthor();
                    MessageBox.Show("Xóa thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }
        private void deletePublisher()
        {
            MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Publisher.Delete(txtPublisherID.Text.Trim());
                    loadDataPublisher();
                    MessageBox.Show("Xóa thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        private void deleteReader()
        {
            MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Reader.Delete(txtReaderID.Text.Trim());
                    loadDataReader();
                    MessageBox.Show("Xóa thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
        private void deleteReverseReturn()
        {
            MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    ReverseReturn.Delete(txtReg_ID.Text.Trim());
                    loadDataReverseReturn();
                    MessageBox.Show("Xóa thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            
        }
        private void deleteStaff()
        {
            MessageBoxResult res = MessageBox.Show("Bạn chắc chắn muốn xóa chứ ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    staff.Delete(txtStaffID.Text.Trim());
                    loadDataStaff();
                    MessageBox.Show("Xóa thành công!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại!", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }

        #endregion






        #region search
        private void searchBook()
        {
            try
            {
                dgBook.ItemsSource = Book.Search(
                    txtBookID.Text.Trim(),
                    txtBookTitle.Text.Trim(),
                    txtBookCategory.Text.Trim(),
                    txtBookAuthor.Text.Trim(),
                    txtBookPublisher.Text.Trim(),
                    txtYearOfPublication.Text.Trim(),
                    txtBookPrice.Text.Trim(),
                    txtBookQuantity.Text.Trim()
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchAuthor()
        {
            try
            {
                dgAuthor.ItemsSource = Author.Search(
                    txtAuthorID.Text.Trim(),
                    txtAuthorName.Text.Trim()
                    );   
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchPublisher()
        {
            try
            {
                dgPublisher.ItemsSource = Publisher.Search(
                    txtPublisherID.Text.Trim(),
                    txtPublisherName.Text.Trim(),
                    txtPublisherEmail.Text.Trim(),
                    txtPublisherPhone.Text.Trim(),
                    txtPublisherAddress.Text.Trim()
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void searchReader()
        {
            try
            {
                dgReader.ItemsSource = Reader.Search(
                    txtReaderID.Text.Trim(),
                    txtReaderName.Text.Trim(),
                    txtReaderBirthDay.Text.Trim(),
                    txtReaderSex.Text.Trim(),
                    txtReaderEmail.Text.Trim(),
                    txtReaderPhone.Text.Trim(),
                    txtReaderAddress.Text.Trim()
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void searchReverseReturn()
        {
            try
            {
                dgReserveReturn.ItemsSource = ReverseReturn.Search(
                    txtReg_ID.Text.Trim(),
                    txtReg_ReaderID.Text.Trim(),
                    txtReg_BookID.Text.Trim(),
                    txtReg_ReserveDate.Text.Trim(),
                    txtReg_DueDate.Text.Trim(),
                    txtReturnDate.Text.Trim(),
                    txtReg_ReserveStaffID.Text.Trim(),
                    txtReg_ReturnStaffID.Text.Trim()
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void searchStaff()
        {
            try
            {
                dgStaff.ItemsSource = staff.Search(
                    txtStaffID.Text.Trim(),
                    txtStaffName.Text.Trim(),
                    txtStaffBirthday.Text.Trim(),
                    txtStaffSex.Text.Trim(),
                    txtStaffEmail.Text.Trim(),
                    txtStaffPhone.Text.Trim(),
                    txtStaffAddress.Text.Trim(),
                    txtStaffStartDate.Text.Trim(),
                    txtStaffSalary.Text.Trim()
                    );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
