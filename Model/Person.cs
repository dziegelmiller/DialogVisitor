using CommunityToolkit.Mvvm.ComponentModel;

namespace DialogVisitorView.Model
{
    public partial class Person : ObservableObject 
    {

        [ObservableProperty]
        public string? _firstName;

        [ObservableProperty]
        private string? _lastName;


        [ObservableProperty]
        private string? _phone;

    }
}
