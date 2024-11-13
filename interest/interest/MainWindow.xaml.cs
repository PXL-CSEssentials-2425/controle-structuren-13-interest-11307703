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

namespace interest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Clear();
            beginKapTextBox.Clear();
            eindKapTextBox.Clear(); 
            interestVoetTextBox.Clear();
            beginKapTextBox.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {   
            StringBuilder sb = new StringBuilder();
            decimal beginKapitaal = decimal.Parse(beginKapTextBox.Text);
            decimal eindKapitaal = decimal.Parse(eindKapTextBox.Text);
            decimal interest = decimal.Parse(interestVoetTextBox.Text);
            int jaren = 0;
            decimal result = beginKapitaal;

            while (result < eindKapitaal)
            {
                result = beginKapitaal *= (1 + interest / 100);
                jaren++;
                sb.AppendLine($"Waarde na {jaren} jaar:€{Math.Round(result)}");
            }
            resultTextBox.Text = sb.ToString();
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back || e.Key == Key.OemComma)
            {
                e.Handled = false; //let op tijdens leren bij examen: e.handled default value is false dwz tekst binnenin acolades kan ook leeggelaten worden
            }
            else if (e.Key >= Key.D0 && e.Key <= Key.D9)
            {
                e.Handled |= false; // zie vorige comment
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Only a comma or number please", "Foutief", MessageBoxButton.OK ,MessageBoxImage.Question);

            }
        }
    }
}