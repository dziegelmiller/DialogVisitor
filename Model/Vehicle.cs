using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;


namespace DialogVisitorView.Model
{
    public partial class Vehicle : ObservableObject 
    {

        [ObservableProperty]
        private string? _make;

        [ObservableProperty]
        private string? _model;

        [ObservableProperty]
        private string? _year;
    }
}
