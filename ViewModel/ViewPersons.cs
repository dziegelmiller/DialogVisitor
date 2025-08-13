using DialogVisitorView.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using CommunityToolkit.Mvvm.Input;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;

namespace DialogVisitorView.ViewModel
{
    public partial class ViewPersons : ObservableObject
    {
        /// <summary>
        /// The visitor class which is invoked to pop up the dialogs.
        /// The functional instance is injected by the mainWindow Loaded event handler
        /// </summary>
        public ViewModel.DialogVisitor? Visitor { get; set; }
    
        public ViewPersons()
        {
            PersonList = new ObservableCollection<Person>();
            PersonListView = CollectionViewSource.GetDefaultView(PersonList);
        }

        /// <summary>
        /// The property the datagrid is bound to
        /// </summary>
        public ICollectionView PersonListView { get; private set; }

        /// <summary>
        /// The collection of Person objects
        /// </summary>
        private ObservableCollection<Model.Person> PersonList { get; set; }

        /// <summary>
        /// The method commanded when the Update Person button is clicked;
        /// CanUpdatePerson is used to enable/disable the button based on the
        /// state of the PersonListView.CurrentItem and the Visitor.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanUpdatePerson))]
        public void UpdatePerson()
        {
            // Invoke the visitor.  DynamicVisit will call the Visit method which has
            // the Person argument, which creates and shows the dialog.
            Visitor?.DynamicVisit((Person)PersonListView.CurrentItem);
        }

        /// <summary>
        /// Enable/disable the Update Person button.  Note that the
        /// SelectionChanged event of the DataGrid is needed to NotifyCanExecuteChanged,
        /// implemented in the MainWindow.xaml.cs
        /// </summary>
        /// <returns>true if button (command) should be enabled</returns>
        private bool CanUpdatePerson()
        {
            // Check if the current item is not null and if the Visitor is set
            return (Person)PersonListView.CurrentItem != null && Visitor != null;
        }

        /// <summary>
        /// The method to create a new Person object and show the dialog
        /// </summary>
        [RelayCommand]
        private void CreatePerson()
        {
            if (Visitor == null) return;

            Person p = new Person();
            // Invoke the visitor.  DynamicVisit will call the Visit method which has
            // the Person argument, which creates and shows the dialog.
            Visitor.DynamicVisit(p);
            PersonList.Add(p);
        }
    }
}
