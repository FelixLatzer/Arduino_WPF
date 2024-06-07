using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using Arduino_WPF.Views.CustomControlls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    public ObservableCollection<CustomPinViewModel> Pins { get; private set; }
    public ObservableCollection<string> AvailablePorts { get; private set; }
    private COM? _com;

    private string _selectedPort;
    public string SelectedPort
    {
        get => _selectedPort;
        set
        {
            if (_selectedPort != value)
            {
                _selectedPort = value;
                OnPropertyChanged();
            }
        }
    }

    public COM COM
    {
        get => _com!;
        private set
        {
            if (_com != value)
            {
                _com = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand OpenCOMCommand { get; }
    public ICommand CloseCOMCommand { get; }
    public ICommand RefreshPinsCommand { get; }
    public ICommand ListPortsCommand { get; }
    public ICommand AddNewPin { get; }

    public MainWindowViewModel()
    {
        Pins = new ObservableCollection<CustomPinViewModel>();
        AvailablePorts = new ObservableCollection<string>();
        OpenCOMCommand = new RelayCommand(OpenCOM);
        CloseCOMCommand = new RelayCommand(CloseCOM);
        RefreshPinsCommand = new RelayCommand(RefreshPins);
        ListPortsCommand = new RelayCommand(ListPorts);
        AddNewPin = new RelayCommand(AddCustomPin);
    }

    private void AddCustomPin()
    {
        Pins.Add(new(1, PinMode.OUTPUT, State.LOW));
    }

    private void OpenCOM()
    {
        if (!string.IsNullOrEmpty(SelectedPort))
        {
            COM = new COM(9600, SelectedPort, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);

            try
            {
                COM.OpenConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        else
        {
           MessageBox.Show("Please select a port first.");
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
                MessageBox.Show(ex.Message);
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

    private void ListPorts()
    {
        AvailablePorts.Clear();
        foreach (var port in COM.ListOpenPorts())
        {
            AvailablePorts.Add(port);
        }
    }

    public void AddPin(int id, PinMode pinMode, State state)
    {
        var pinViewModel = new CustomPinViewModel(id, pinMode, state);
        Pins.Add(pinViewModel);
    }
}