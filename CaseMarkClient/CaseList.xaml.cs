using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CaseMarkClient
{
    /// <summary>
    /// Interaction logic for CaseList.xaml
    /// </summary>
    public partial class CaseList : Page
    {
        private List<Cases> cases;
        
        public CaseList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            updatelist();
        }
        private void updatelist()
        {
            cases = new List<Cases>();

            cases = DBControl.GetAllCases();

            caseLists.ItemsSource = cases;
            CNumber.ItemsSource = cases;
        }
        private void CNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox tmp = (ComboBox)sender;
            Cases tmpc = (Cases)tmp.SelectedItem;
            List<Cases> tmpcases = new List<Cases>();
            if (tmpc != null)
            {
                foreach (Cases c in cases)
                {
                    if (c.CaseNumber == tmpc.CaseNumber)
                        tmpcases.Add(c);
                }
                caseLists.ItemsSource = tmpcases;
            }
            else
                caseLists.ItemsSource = cases;
        }

        private void CName_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tmptxt = (TextBox)sender;
            if (tmptxt.Text != string.Empty && tmptxt.Text.Length > 2)
            {
                List<Cases> tmpcases = new List<Cases>();
                foreach (Cases c in cases)
                {
                    if (c.CaseName.Contains(tmptxt.Text))
                        tmpcases.Add(c);
                }
                caseLists.ItemsSource = tmpcases;
            }
            else
                caseLists.ItemsSource = cases;
        }

        private void CSides_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tmptxt = (TextBox)sender;
            if (tmptxt.Text != string.Empty && tmptxt.Text.Length > 2)
            {
                List<Cases> tmpcases = new List<Cases>();
                foreach (Cases c in cases)
                {
                    if (c.CaseSides.Contains(tmptxt.Text))
                        tmpcases.Add(c);
                }
                caseLists.ItemsSource = tmpcases;
            }
            else
                caseLists.ItemsSource = cases;
        }

        private void caseDt_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker tmpdate = (DatePicker)sender;
            if (tmpdate.SelectedDate != null)
            {
                List<Cases> tmcpc = new List<Cases>();
                foreach (Cases c in cases)
                {
                    if(c.Date.CompareTo(tmpdate.SelectedDate.Value) > 0)
                    {
                        tmcpc.Add(c);
                    }
                }
                caseLists.ItemsSource = tmcpc;
            }
            else
                caseLists.ItemsSource = cases;
        }

        private void editbtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Cases c = (Cases)btn.Tag;
            MainWindow.loadeditcase?.Invoke(c);
        }

        private void deleteCaseBtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Cases c = (Cases)btn.Tag;

            MessageBoxResult res = MessageBox.Show("ნამდვილად გსურთ საქმის წაშლა", "შეკითხვა", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(res == MessageBoxResult.Yes)
            {
                int i = DBControl.DelteCase(c);
                if(i > 0)
                {
                    MessageBox.Show("საქმე წაიშლა წარმატებით");
                    updatelist();
                }
                else
                {
                    MessageBox.Show("გაუთვალისწინებელი შეცდომა", "შეცდომა", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                    
            }
        }
    }
}
