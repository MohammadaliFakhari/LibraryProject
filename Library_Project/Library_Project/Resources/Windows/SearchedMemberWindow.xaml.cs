﻿using System;
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
using System.Windows.Shapes;
using Library_Project.Resources.Classes;
using Library_Project.Resourses.Windows;

namespace Library_Project.Resources.Windows
{
    /// <summary>
    /// Interaction logic for SearchedMemberWindow.xaml
    /// </summary>
    public partial class SearchedMemberWindow : Window
    {
        public SearchedMemberWindow(string username)
        {
            InitializeComponent();
            if (Employees.SearchAllMember(username).Count != 0)
            {
                var member = Employees.SearchAllMember(username)[0];
                image.Source = ImageControl.ByteToImage(member.Image);
                txtUsername.Text = member.UserName;
                txtEmail.Text = member.Email;
                txtPhoneNumber.Text = member.PhoneNumber;
                txtRegisterDay.Text = member.RegisteryDay;
                txtsubscription.Text = member.SubsriptionDateRenewal;

                DateTime a = DateTime.Parse(DateTime.Now.ToShortDateString());
                DateTime b = DateTime.Parse(member.SubsriptionDate);
                TimeSpan result = b - a;

                if (int.Parse(result.TotalDays.ToString()) > 0)
                {
                    txtsubscriptionRemain.Background = new SolidColorBrush(Colors.Green);
                    txtsubscriptionRemain.Foreground = new SolidColorBrush(Colors.Black);
                    txtsubscriptionRemain.Text = int.Parse(result.TotalDays.ToString()).ToString() + "روز باقی مانده";
                }
                else
                {
                    txtsubscriptionRemain.Background = new SolidColorBrush(Colors.Red);
                    txtsubscriptionRemain.Foreground = new SolidColorBrush(Colors.Black);
                    txtsubscriptionRemain.Text = Math.Abs(int.Parse(result.TotalDays.ToString())) + "روز گذشته است";
                }
                if (BorrowedBook.infoBorrowed(username).Count != 0)
                {
                    var Borrowed = BorrowedBook.infoBorrowed(username);
                    BookBorrowed.Visibility = Visibility.Visible;
                    for(int i=0;i< BorrowedBook.infoBorrowed(username).Count; i++)
                    {
                        if (int.Parse(BorrowedBook.infoBorrowed(username)[i].remainDate) > 0)
                        {
                            Borrowed[i].remainDate += "روز باقی مانده است";
                        }
                        if (int.Parse(BorrowedBook.infoBorrowed(username)[i].remainDate) < 0)
                        {
                            Borrowed[i].remainDate += "روز گذشته است";
                        }
                    }
                    BookBorrowed.ItemsSource = Borrowed;
                }
                else
                {
                    Emty.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("چنین کابری یافت نشد");
            }
                
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}