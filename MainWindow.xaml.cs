using DialogVisitorView.ViewModel;
using System.Windows;

namespace DialogVisitorView
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

        private ViewModel.ViewPersons? viewPersons;
        private ViewVehicles? viewVehicles;

        /// <summary>
        /// The visitor class which is invoked to pop up the dialogs, per the Visitor pattern.
        /// </summary>
        private DialogVisitor? Visitor;


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Visitor = new DialogVisitor();

            // retrieve the object created by xaml from the resources and 
            // use property injection to add the Visitor
            viewPersons = (ViewPersons)this.Resources["viewPersons"];
            viewPersons.Visitor = Visitor;

            // do the same for vehicle
            viewVehicles = (ViewVehicles)this.Resources["viewVehicles"];
            viewVehicles.Visitor = Visitor;
        }

        /// <summary>
        /// Handles the selection event for the person grid.
        /// </summary>
        /// <remarks>This method updates the state of the associated command to reflect whether it can be
        /// executed, based on the current selection in the person grid.</remarks>
        /// <param name="sender">The source of the event, typically the person grid control.</param>
        /// <param name="e">The event data associated with the selection event.</param>
        private void PersonGrid_Selected(object sender, RoutedEventArgs e)
        {
            viewPersons?.UpdatePersonCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Handles the selection change event for the vehicle grid.
        /// </summary>
        /// <remarks>This method updates the state of the <see cref="viewVehicles.UpdateVehicleCommand"/> 
        /// by notifying that its execution status may have changed.</remarks>
        /// <param name="sender">The source of the event, typically the vehicle grid control.</param>
        /// <param name="e">The event data containing information about the selection change.</param>
        private void VehicleGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            viewVehicles?.UpdateVehicleCommand.NotifyCanExecuteChanged();
        }
    }
}
