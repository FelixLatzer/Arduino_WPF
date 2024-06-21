using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

    public COM COM { get; set; }

    private SerialReader _serialReader;

    /// <summary>
    /// This is the constructor of the PinViewViewModel class.
    /// </summary>
    /// <param name="com"></param>
    /// <param name="reader"></param>
    public PinViewViewModel(COM com, SerialReader reader)
    {
        AddPinCommand = new RelayCommandWithParameter(AddPin);
        COM = com;
        _serialReader = reader;
        _serialReader.PropertyChanged += SerialReaderPropertyChanged;
    }

    /// <summary>
    /// This method is called when the SerialReader property changes.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void SerialReaderPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_serialReader.LastReceivedPinConfig))
        {
            ChangePinIfOpened(_serialReader.LastReceivedPinConfig);
        }
    }

    /// <summary>
    /// This method changes the pin if it is opened.
    /// </summary>
    /// <param name="receivedPinConfig"></param>
    private void ChangePinIfOpened(Pin receivedPinConfig)
    {
        foreach (var pin in  Pins)
        {
            if (pin.ID == receivedPinConfig.Id)
            {
                pin.PinMode = receivedPinConfig.Mode;
                pin.SelectedPinMode = receivedPinConfig.Mode;
                pin.State = receivedPinConfig.State;
                pin.SelectedState = receivedPinConfig.State;
            }
        }
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

        Pins.Add(new(pinId, Models.PinMode.Input, Models.State.Low, COM, RemovePin));
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
