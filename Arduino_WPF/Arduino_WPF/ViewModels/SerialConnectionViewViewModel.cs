using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Windows;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class SerialConnectionViewViewModel : BaseViewModel
{
    public ObservableCollection<CustomPinViewModel> Pins { get; private set; }
    public ObservableCollection<string> AvailablePorts { get; private set; }
    public ObservableCollection<PinMode> PinModes { get; private set; }
    public ObservableCollection<State> PinStates { get; private set; }
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

    private string _serialOutput;
    public string SerialOutput
    {
        get => _serialOutput;
        set
        {
            if (_serialOutput != value)
            {
                _serialOutput = value;
                OnPropertyChanged();
            }
        }
    }

    private CustomPinViewModel _selectedPin;
    public CustomPinViewModel SelectedPin
    {
        get => _selectedPin;
        set
        {
            _selectedPin = value;
            OnPropertyChanged();
        }
    }

    private PinMode _selectedPinMode;
    public PinMode SelectedPinMode
    {
        get => _selectedPinMode;
        set
        {
            _selectedPinMode = value;
            OnPropertyChanged();
        }
    }

    private State _selectedState;
    public State SelectedState
    {
        get => _selectedState;
        set
        {
            _selectedState = value;
            OnPropertyChanged();
        }
    }

    private string _readPinConfiguration;
    public string ReadPinConfiguration
    {
        get => _readPinConfiguration;
        set
        {
            _readPinConfiguration = value;
            OnPropertyChanged();
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
    public RelayCommand ClearSerialOutputCommand { get; }
    public ObservableCollection<Parity> ParityValues { get; private set; }
    public ObservableCollection<StopBits> StopBitsValues { get; private set; }
    public ICommand WritePinCommand { get; }
    public ICommand ReadPinCommand { get; }
    public ICommand LoadPresetConfigurationsCommand { get; }
    public PresetJsonLoader SelectedPresetConfiguration { get; set; }
    public List<PresetJsonLoader> PresetConfigurations { get => PresetJsonLoader.GetPresetConfigurations(); }

    public SerialConnectionViewViewModel()
    {
        ParityValues = new ObservableCollection<Parity>(Enum.GetValues(typeof(Parity)).Cast<Parity>());
        StopBitsValues = new ObservableCollection<StopBits>(Enum.GetValues(typeof(StopBits)).Cast<StopBits>());
        Pins = new ObservableCollection<CustomPinViewModel>();
        PinModes = new ObservableCollection<PinMode>(Enum.GetValues(typeof(PinMode)).Cast<PinMode>());
        PinStates = new ObservableCollection<State>(Enum.GetValues(typeof(State)).Cast<State>());
        AvailablePorts = new ObservableCollection<string>();
        OpenCOMCommand = new RelayCommand(OpenCOM);
        CloseCOMCommand = new RelayCommand(CloseCOM);
        RefreshPinsCommand = new RelayCommand(RefreshPins);
        ListPortsCommand = new RelayCommand(ListPorts);
        ClearSerialOutputCommand = new RelayCommand(ClearSerialOutput);
        WritePinCommand = new RelayCommand(WritePinConfiguration);
        ReadPinCommand = new RelayCommand(ReadPinConfigurationFromCOM);
        LoadPresetConfigurationsCommand = new RelayCommand(LoadPresetConfigurations);

        // Default values
        BaudRate = 9600;
        Parity = Parity.None;
        DataBits = 8;
        StopBits = StopBits.One;

        Task.Run(ReadSerialLoop);
    }

    private void OpenCOM()
    {
        if (!string.IsNullOrEmpty(SelectedPort))
        {
            COM = new COM(BaudRate, SelectedPort, Parity, DataBits, StopBits);

            try
            {
                COM.OpenConnection();
                MessageBox.Show($"Connection to {COM.Port} opened.");
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
                MessageBox.Show($"Connection to {COM.Port} closed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    private void RefreshPins()
    {
        if (COM == null)
        {
            MessageBox.Show("Please open a connection first.");
            return;
        }

        ReadPinConfiguration = COM.ReadPinConfiguration();
        if (!string.IsNullOrEmpty(ReadPinConfiguration))
        {
            ParseJsonConfiguration(ReadPinConfiguration);
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
        var pinViewModel = new CustomPinViewModel(id, pinMode, state, RemovePin);
        Pins.Add(pinViewModel);
    }

    public void RemovePin(CustomPinViewModel pin)
    {
        Pins.Remove(pin);
    }

    public void UpdatePin(int id, State state, PinMode pinMode)
    {
        var pinViewModel = Pins.FirstOrDefault(p => p.ID == id);
        if (pinViewModel != null)
        {
            pinViewModel.UpdateState();
        }
    }

    private async Task ReadSerialLoop()
    {
        while (true)
        {
            if (COM != null)
            {
                string output = COM.ReadSerialOutput();
                if (!string.IsNullOrEmpty(output))
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        SerialOutput += output;
                        ParseJsonConfiguration(output);
                    });
                }
            }
            await Task.Delay(100);
        }
    }

    public void ClearSerialOutput()
    {
        SerialOutput = string.Empty;

        if (COM != null)
        {
            COM.ClearSerialOutput();
        }
    }

    public void WritePinConfiguration()
    {
        if (SelectedPresetConfiguration != null)
        {
            var pinData = new[]
            {
                new
                {
                    Id = SelectedPresetConfiguration.Id,
                    Mode = SelectedPresetConfiguration.Mode,
                    State = SelectedPresetConfiguration.State
                }
            };

            string pinDataJson = JsonConvert.SerializeObject(pinData);

            if (COM != null)
            {
                COM.WriteSerialOutput(pinDataJson);
            }
        }
        else
        {
            MessageBox.Show("Please select a preset configuration.");
        }
    }

    private void ParseJsonConfiguration(string json)
    {
        var jsonObjects = COM.ExtractJsonObjects(ref json);
        foreach (var jsonObject in jsonObjects)
        {
            if (jsonObject.ContainsKey("id") && jsonObject.ContainsKey("mode") && jsonObject.ContainsKey("state"))
            {
                int id = jsonObject["id"].Value<int>();
                PinMode pinMode = (PinMode)Enum.Parse(typeof(PinMode), jsonObject["mode"].Value<string>(), true);
                State state = (State)jsonObject["state"].Value<int>();

                Application.Current.Dispatcher.Invoke(() =>
                {
                    var pinViewModel = Pins.FirstOrDefault(p => p.ID == id);
                    if (pinViewModel == null)
                    {
                        AddPin(id, pinMode, state);
                    }
                    else
                    {
                        pinViewModel.UpdateState();
                    }
                });
            }
        }
    }


    private void ReadPinConfigurationFromCOM()
    {
        if (COM != null)
        {
            string data = COM.ReadSerialOutput();
            if (!string.IsNullOrEmpty(data))
            {
                ParseJsonConfiguration(data);
            }
        }
    }

    private void LoadPresetConfigurations()
    {
        if (SelectedPresetConfiguration != null)
        {
            var presetConfigurations = new[]
            {
                new PresetJsonLoader { Id = SelectedPresetConfiguration.Id, Mode = SelectedPresetConfiguration.Mode, State = SelectedPresetConfiguration.State }
            };

            string presetConfigurationsJson = JsonConvert.SerializeObject(presetConfigurations);

            if (COM != null)
            {
                COM.WriteSerialOutput(presetConfigurationsJson);
            }
        }
        else
        {
            MessageBox.Show("Please select a preset configuration.");
        }
    }
}