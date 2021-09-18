using System;
using System.Windows;
using System.Windows.Input;

namespace CaseMarkClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public delegate void LoadEditCase(Cases c);
    
    public partial class MainWindow : Window
    {
       
        public static LoadEditCase loadeditcase;
        public MainWindow()
        {
            InitializeComponent();
            loadeditcase = loadcase;
        }

        private void menuCloseBtn_Click(object sender, RoutedEventArgs e)
        {
            expandMenu.Visibility = Visibility.Collapsed;
            minMenu.Visibility = Visibility.Visible;
        }

        private void loadcase(Cases c)
        {
           
            EditCase.editcase = c;
            mainFrame.Source = new Uri("EditCase.xaml", UriKind.Relative);
        }
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            expandMenu.Visibility = Visibility.Visible;
            minMenu.Visibility = Visibility.Collapsed;
        }

        private void addCaseBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Source = new Uri("CaseList.xaml", UriKind.Relative);
        }

       

        private void caseAddBtn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mainFrame.Source = new Uri("AddCase.xaml", UriKind.Relative);
        }
    }
}
