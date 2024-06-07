using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Windows;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    public ObservableCollection<CustomPinViewModel> Pins { get; private set; }
    public ObservableCollection<string> AvailablePorts { get; private set; }
    private COM? _com;

    private int _baudRate;
    public int BaudRate
    {
        get => _baudRate;
        set
        {
            if (_baudRate != value)
            {
                _baudRate = value;
                OnPropertyChanged();
            }
        }
    }

    private Parity _parity;
    public Parity Parity
    {
        get => _parity;
        set
        {
            if (_parity != value)
            {
                _parity = value;
                OnPropertyChanged();
            }
        }
    }

    private int _dataBits;
    public int DataBits
    {
        get => _dataBits;
        set
        {
            if (_dataBits != value)
            {
                _dataBits = value;
                OnPropertyChanged();
            }
        }
    }

    private StopBits _stopBits;
    public StopBits StopBits
    {
        get => _stopBits;
        set
        {
            if (_stopBits != value)
            {
                _stopBits = value;
                OnPropertyChanged();
            }
        }
    }

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
    public ObservableCollection<Parity> ParityValues { get; private set; }
    public ObservableCollection<StopBits> StopBitsValues { get; private set; }

    public MainWindowViewModel()
    {
        ParityValues = new ObservableCollection<Parity>(Enum.GetValues(typeof(Parity)).Cast<Parity>());
        StopBitsValues = new ObservableCollection<StopBits>(Enum.GetValues(typeof(StopBits)).Cast<StopBits>());
        Pins = new ObservableCollection<CustomPinViewModel>();
        AvailablePorts = new ObservableCollection<string>();
        OpenCOMCommand = new RelayCommand(OpenCOM);
        CloseCOMCommand = new RelayCommand(CloseCOM);
        RefreshPinsCommand = new RelayCommand(RefreshPins);
        ListPortsCommand = new RelayCommand(ListPorts);

        // Default Stop
        BaudRate = 9600;
        Parity = Parity.None;
        DataBits = 8;
        StopBits = StopBits.One;
    }

    private void OpenCOM()
    {
        if (!string.IsNullOrEmpty(SelectedPort))
        {
            COM = new COM(BaudRate, SelectedPort, Parity, DataBits, StopBits);

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

    public void RemovePin(int id)
    {
        var pinViewModel = Pins.FirstOrDefault(p => p.ID == id);
        if (pinViewModel != null)
        {
            Pins.Remove(pinViewModel);
        }
    }

    public void UpdatePin(int id, State state, PinMode pinMode)
    {
        var pinViewModel = Pins.FirstOrDefault(p => p.ID == id);
        if (pinViewModel != null)
        {
            pinViewModel.UpdateState();
        }
    }
}