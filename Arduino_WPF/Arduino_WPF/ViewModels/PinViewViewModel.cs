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

    private COM _com;

    public PinViewViewModel(COM com) 
    {
        AddPinCommand = new RelayCommand(AddPin);

        _com = com;
    }

    /// <summary>
    /// This method adds a pin to the Pins collection.
    /// </summary>
    private void AddPin()
    {
        Pins.Add(new(1, Models.PinMode.Input, Models.State.Low, RemovePin));
    }

    /// <summary>
    /// This method removes a pin from the Pins collection.
    /// </summary>
    /// <param name="pin"></param>
    private void RemovePin(CustomPinViewModel pin)
    {
        Pins.Remove(pin);
    }
}
