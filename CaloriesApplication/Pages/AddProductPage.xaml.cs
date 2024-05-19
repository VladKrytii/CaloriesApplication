using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaloriesApplication
{
    /// <summary>
    /// Interaction logic for AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public AddProductPage()
        {
            InitializeComponent();
            lvProducts.Items.Add("a");
            lvProducts.Items.Add("b");
            lvProducts.Items.Add("c");
            lvProducts.Items.Add("d");
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lvProducts.Items.Add(txtEntry.Text);
        }

    }
}
