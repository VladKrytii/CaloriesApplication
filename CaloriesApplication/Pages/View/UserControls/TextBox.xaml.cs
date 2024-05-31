using System.Windows.Controls;
using System.Windows;

namespace CaloriesApplication.Pages.View.UserControls
{
    public partial class TextBox : UserControl
    {
        public TextBox()
        {
            InitializeComponent();
        }

        private string placeholder;

        public string Placeholder
        {
            get { return placeholder; }

            set {

                placeholder = value;
                //bed code
                tbPlaceholder.Text = placeholder;

                //OnPropertyChanged()
            }


        }

        private void btnClear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            txtInput.Clear();
            txtInput.Focus();
        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text)) 
                tbPlaceholder.Visibility = Visibility.Visible;
            else tbPlaceholder.Visibility = Visibility.Hidden;
        }
    }
}
