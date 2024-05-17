using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using Microsoft.Extensions.Logging;

namespace Arduino_WPF.ViewModels;


public class MainWindowViewModel : BaseViewModel
{
    public ObservableCollection<CustomPinViewModel> Pins { get; private set; }
    public COM? COM { get; private set; }

    public ICommand OpenCOMCommand { get; }
    public ICommand CloseCOMCommand { get; }
    public ICommand RefreshPinsCommand { get; }

    public MainWindowViewModel()
    {
        Pins = [];
        OpenCOMCommand = new RelayCommand(OpenCOM);
        CloseCOMCommand = new RelayCommand(CloseCOM);
        RefreshPinsCommand = new RelayCommand(RefreshPins);
    }

    private void OpenCOM()
    {
        var ports = System.IO.Ports.SerialPort.GetPortNames();

        foreach (var port in ports)
        {
            COM = new COM(9600, port, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            try
            {
                COM.OpenConnection();
                break;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                COM = null;
            }
        }
    }

    private void CloseCOM()
    {
        if (COM != null)
        {
            try
            {
                COM.CloseConnection();
            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                COM = null;
            }
        }
    }

    private void RefreshPins()
    {
        foreach (var pinViewModel in Pins)
        {
            pinViewModel.UpdateState();
        }
    }

    public void AddPin(int id, PinMode pinMode, State state)
    {
        var pinViewModel = new CustomPinViewModel(id, pinMode, state);
        Pins.Add(pinViewModel);
    }
}
