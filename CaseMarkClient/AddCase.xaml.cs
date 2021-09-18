using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CaseMarkClient
{
    /// <summary>
    /// Interaction logic for AddCase.xaml
    /// </summary>
    public partial class AddCase : Page
    {
        private List<string> hours;
        private List<string> minutes;
        private List<Judge> judges;
        public AddCase()
        {
            InitializeComponent();
        }

        private void AddCase_Loaded(object sender, RoutedEventArgs e)
        {
            hours = new List<string>();
            minutes = new List<string>();
            judges = DBControl.GetAllJudge();
            for (int i = 0; i < 60; i++)
            {
                minutes.Add(i.ToString());
                if(i > 7 && i< 24)
                {
                    hours.Add(i.ToString());
                }
            }
            CDate.SelectedDate = DateTime.Now.Date;
            CHour.ItemsSource = hours;
            CMinute.ItemsSource = minutes;
            CHour.SelectedIndex = (DateTime.Now.Hour - 8);
            CMinute.SelectedIndex = DateTime.Now.Minute;
            CJudges.ItemsSource = judges;
        }

        private void CAddedBtn_Click(object sender, RoutedEventArgs e)
        {
            string cnumber = CNumber.Text.Trim();
            string cname = CName.Text.Trim();
            string csides = CSide.Text.Trim();
            Judge judge = (Judge)CJudges.SelectedItem;
            if(cnumber == string.Empty || cname == string.Empty || csides == string.Empty)
            {
                MessageBox.Show("საქმის ნომერი, დასახელება, ან მხარეები არ შეიძლება იყოს ცარიელი", "გაფრთხილება", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(judge == null)
            {
                MessageBox.Show("აირჩიეთ მოსამართლე","გაფრხილება",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            DateTime cdate = new DateTime(
                CDate.SelectedDate.Value.Year,
                CDate.SelectedDate.Value.Month,
                CDate.SelectedDate.Value.Day,
                Convert.ToInt32(CHour.SelectedItem),
                Convert.ToInt32(CMinute.SelectedItem),
                00);

            Cases c = new Cases(judge, cnumber,cname, csides, cdate);
            MessageBoxResult res =  MessageBox.Show("ნამდვილად გსურთ საქმის ჩანიშვნა", "გაფრთხილება", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(res== MessageBoxResult.Yes)
            {
                int i = DBControl.InsertCase(c);
                if (i > 0)
                    MessageBox.Show("საქმე ჩაინიშნა წარმატებით");
                else
                {
                    MessageBox.Show("გაუთვალისწინებელი შეცდომა", "შეცდომა", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            
           
                
        }
    }
}
