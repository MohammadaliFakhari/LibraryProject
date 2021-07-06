﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using System.Windows.Shapes;
using Library_Project.Resources.Classes;
using Library_Project.Resourses.Windows;

namespace Library_Project.Resources.Windows
{
    /// <summary>
    /// Interaction logic for MemberDashboard.xaml
    /// </summary>
    public partial class MemberDashboard : Window, INotifyPropertyChanged
    {
        public string SearchBoxText { get; set; }

        private List<Book> _availableBooks;
        private List<BorrowedBook> _borrowedBooks;
        private List<string> _nameCollection;

        public List<Book> AvailableBooks
        {
            get { return _availableBooks; }
            set { _availableBooks = value; NotifyPropertyChanged("AvailableBooks"); }
        }

        public List<BorrowedBook> BorrowedBooks
        {
            get { return _borrowedBooks; }
            set { _borrowedBooks = value; NotifyPropertyChanged("BorrowedBooks"); }
        }

        public List<string> NameCollection
        {
            get => _nameCollection;
            set { _nameCollection = value; NotifyPropertyChanged("NameCollection"); }
        }

        private string Username { get; set; }
        private decimal Money { get; set; }

        public MemberDashboard(string username)
        {
            Money = Member.GetMemberMoney(username);
            Username = username;

            InitializeComponent();
            DataContext = this;

            UpdateAvailableBoosData();
            UpdateMyBooksData();
            NameCollection = Book.GetAllNames(Username).ToList();

            money.Text = Money.ToString("C0", CultureInfo.CreateSpecificCulture("fa-ir"));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void HomePn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HomePan.Visibility = Visibility.Visible;
            BookPan.Visibility = Visibility.Collapsed;
            MyBooksPan.Visibility = Visibility.Collapsed;
            WalletPan.Visibility = Visibility.Collapsed;
        }
        private void BooksPn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HomePan.Visibility = Visibility.Collapsed;
            BookPan.Visibility = Visibility.Visible;
            MyBooksPan.Visibility = Visibility.Collapsed;
            WalletPan.Visibility = Visibility.Collapsed;
        }
        private void MyBooksPn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HomePan.Visibility = Visibility.Collapsed;
            BookPan.Visibility = Visibility.Collapsed;
            MyBooksPan.Visibility = Visibility.Visible;
            WalletPan.Visibility = Visibility.Collapsed;
        }
        private void WalletPn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HomePan.Visibility = Visibility.Collapsed;
            BookPan.Visibility = Visibility.Collapsed;
            MyBooksPan.Visibility = Visibility.Collapsed;
            WalletPan.Visibility = Visibility.Visible;
        }

        private void AccountPn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HomePan.Visibility = Visibility.Collapsed;
            BookPan.Visibility = Visibility.Collapsed;
            MyBooksPan.Visibility = Visibility.Collapsed;
            WalletPan.Visibility = Visibility.Collapsed;
        }
        private void LoginPn_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
        private void BookName_Checked(object sender, RoutedEventArgs e)
        {
            //TextOfSearch.Text = "نام کتابی که می خواهید بر اساس آن جستوجو کنید را وارد کنید.";
            SearchBoxText = "نام کتاب";
            AuthorName.IsChecked = false;
        }

        private void Author_Checked(object sender, RoutedEventArgs e)
        {
            //TextOfSearch.Text = "نام نویسنده ای که می خواهید بر اساس آن جستوجو کنید را وارد کنید.";
            SearchBoxText = "نام نویسنده";
            BookName.IsChecked = false;
        }

        private void BookName_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAllCheckBoxes();
        }

        private void Author_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckAllCheckBoxes();
        }

        /// <summary>
        /// a method for checking if all checkboxes are empty or not
        /// </summary>

        private void CheckAllCheckBoxes()
        {
            if (AuthorName.IsChecked == false && BookName.IsChecked == false)
            {
                //TextOfSearch.Text = "";
                SearchBox.Text = "";
            }
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            Payment payment = new Payment(typeOfUser.MemberFromMemberWindow, Username);
            payment.Show();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string kindOfSearch;

            if (AuthorName.IsChecked == false && BookName.IsChecked == false)
            {
                MessageBox.Show(".لطفا ابتدا یکی از دو مورد داخل چک باکس را انتخاب کنید");
                return;
            }
            else if (AuthorName.IsChecked == true)
                kindOfSearch = "author";
            else kindOfSearch = "name";

            SearchedBookWindow window = new SearchedBookWindow(Username, kindOfSearch, SearchBox.Text);
            if (window.ShowBook())
                window.Show();
        }

        private void Borrow_Click(object sender, RoutedEventArgs e)
        {
            if (!AbleToBorrow())
            {
                BorrowedName.Clear();
                return;
            }

            if (Member.GetBook(BorrowedName.Text, Username))
            {
                UpdateAvailableBoosData();
                UpdateMyBooksData();
                NameCollection = Book.GetAllNames(Username).ToList();
                BorrowedName.Clear();
                MessageBox.Show(".کتاب با موفقیت به امانت گرفته شد");
                return;
            }

            MessageBox.Show(".امکان به امانت گرفتن این کتاب موجود نیست");
        }

        private bool AbleToBorrow()
        {
            if (BorrowedBook.infoBorrowed(Username).Count >= 5)
            {
                MessageBox.Show(".تعداد کتاب های شما از حد قابل قبول بیشتر است. لطفا ابتدا تعدادی از کتاب های خود را پس دهید و سپس دوباره این عملیات را تکرار کنید");
                return false;
            }

            var member = Employees.SearchAllMember(Username)[0];
            DateTime a = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime b = DateTime.Parse(member.SubsriptionDate);
            TimeSpan result = b - a;

            if (int.Parse(result.TotalDays.ToString()) < 7)
            {
                MessageBox.Show(".اشتراک شما در کمتر از یک هفتۀ آتی به اتمام می رسد لطفا ابتدا اقدام به تمدید آن کنید و سپس این عملیات را تکرار کنید");
                return false;
            }

            for (int i = 0; i < BorrowedBook.infoBorrowed(Username).Count; i++)
            {
                if (int.Parse(BorrowedBook.infoBorrowed(Username)[i].remainDate) < 0)
                {
                    MessageBox.Show(".لطفا ابتدا به باز پس دادن کتاب هایی که در اختیار دارید اقدام کنید و سپس این عملیات را تکرار کنید");
                    return false;
                }
            }
            return true;
        }

        private void GiveBack_Click(object sender, RoutedEventArgs e)
        {
            var book = BorrowedBooks.FirstOrDefault(x => x.nameBook == GiveBackName.Text);

            if (book == null)
            {
                MessageBox.Show(".کتاب مورد نظر یافت نشد");
                return;
            }

            decimal money;
            if (Member.AbleToReturnBook(book.nameBook, out money))
            {
                if (Member.ReturnBook(book.nameBook, Username))
                {
                    UpdateAvailableBoosData();
                    UpdateMyBooksData();
                    NameCollection = Book.GetAllNames(Username).ToList();
                    MessageBox.Show(".کتاب با موفقیت پس داده شد");
                    return;
                }
            }
            else
            {
                MessageBox.Show($".را به حساب خود واریز کنید و سپس کتاب را پس دهید {money} لطفا در ابتدا مبلغ");
                return;
            }
        }

        private void UpdateAvailableBoosData()
        {
            if (Book.TakeAvailableBooks().Length != 0)
                AvailableBooks = Book.TakeAvailableBooks().ToList();
            else AvailableBooks = new List<Book>();

            if (AvailableBooks.Count > 0)
            {
                availableBooksData.ItemsSource = AvailableBooks;
                availableBooksData.Visibility = Visibility.Visible;
            }
        }

        private void UpdateMyBooksData()
        {
            if (BorrowedBook.infoBorrowed(Username) != null)
                BorrowedBooks = BorrowedBook.infoBorrowed(Username);
            else BorrowedBooks = new List<BorrowedBook>();

            var listOfBooks = BorrowedBooks.Join(AvailableBooks,
                                              borrowedBook => borrowedBook.nameBook,
                                              searchedBook => searchedBook.Name,
                                              (borrowedBook, searchedBook) => new
                                              {
                                                  Name = borrowedBook.nameBook,
                                                  Author = searchedBook.Author,
                                                  Category = searchedBook.Category,
                                                  PublishNumber = searchedBook.PublishNumber,
                                                  gotDate = borrowedBook.gotDate,
                                                  returnDate = borrowedBook.returnDate,
                                                  remainDate = borrowedBook.remainDate
                                              }).ToList();

            if (listOfBooks.Count > 0)
            {
                myBooksData.ItemsSource = listOfBooks;
                myBooksData.Visibility = Visibility.Visible;
            }
            else myBooksData.Visibility = Visibility.Collapsed;
        }

        private void btnSeting_Click(object sender, RoutedEventArgs e)
        {
            CheckEmployeePass check = new CheckEmployeePass(Username, "Member");
            check.Show();
        }
       
    }
}
