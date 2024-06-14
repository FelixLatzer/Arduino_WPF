using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class PinViewViewModel : BaseViewModel
{
    public ObservableCollection<CustomPinViewModel> Pins { get; set; }

    public ICommand AddPinCommand { get; set; }

    public PinViewViewModel() 
    {
        AddPinCommand = new RelayCommand(AddPin);

        Pins = new ObservableCollection<CustomPinViewModel>()
        {
            new(1, Models.PinMode.Output, Models.State.High, RemovePin),
            new(1, Models.PinMode.Output, Models.State.Low, RemovePin)
        };
    }

    private void AddPin()
    {
        Pins.Add(new(1, Models.PinMode.Input, Models.State.Low, RemovePin));
    }

    private void RemovePin(CustomPinViewModel pin)
    {
        Pins.Remove(pin);
    }
}
