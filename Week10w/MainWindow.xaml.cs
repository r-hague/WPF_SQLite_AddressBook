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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Week10w
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private VM vm = new VM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow ew = new EmployeeWindow(vm)
            {
                //make us the owner of this dialog
                Owner = this,
                //so that we can put the dialog centered on us on screen
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };
            ew.ShowDialog();
        }
    }
}
