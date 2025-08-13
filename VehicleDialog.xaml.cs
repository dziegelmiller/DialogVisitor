using System.Windows;

namespace DialogVisitorView
{
    /// <summary>
    /// Interaction logic for VehicleDialog.xaml
    /// </summary>
    public partial class VehicleDialog : Window
    {
        public VehicleDialog()
        {
            InitializeComponent();
        }


        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
