using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class PinViewViewModel : BaseViewModel
{
    public ObservableCollection<CustomPinViewModel> Pins { get; set; } = [];

    public ICommand AddPinCommand { get; set; }

    private COM _com;

    public PinViewViewModel(COM com)
    {
        AddPinCommand = new RelayCommandWithParameter(AddPin);
        _com = com;
    }

    /// <summary>
    /// This method adds a pin to the Pins collection.
    /// </summary>
    private void AddPin(object parameter)
    {
        bool isSuccess = int.TryParse(parameter as string, out var pinId);

        if (!isSuccess)
        {
            return;
        }

        foreach (var pin in Pins)
        {
            if (pin.ID == pinId)
            {
                MessageBox.Show("Pin already opened!");
                return;
            }
        }

        Pins.Add(new(pinId, Models.PinMode.Input, Models.State.Low, RemovePin));
    }

    /// <summary>
    /// This method removes a pin from the Pins collection.
    /// </summary>
    /// <param name="pin"></param>
    private void RemovePin(object parameter)
    {
        if (parameter is not CustomPinViewModel || parameter is null)
        {
            return;
        }

        CustomPinViewModel pin = parameter as CustomPinViewModel;
        Pins.Remove(pin);
    }
}
