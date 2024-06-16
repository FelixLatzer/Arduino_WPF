using Microsoft.Win32;
using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace Arduino_WPF.ViewModels;

public class SerialConnectionViewViewModel : BaseViewModel
{
    public ObservableCollection<CustomPinViewModel> Pins { get; private set; }
    public ObservableCollection<string> AvailablePorts { get; private set; }
    public ObservableCollection<PinMode> PinModes { get; private set; }
    public ObservableCollection<State> PinStates { get; private set; }
    private COM _com;

    /// <summary>
    /// Gets or sets the baud rate of the serial connection.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the parity of the serial connection.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the data bits of the serial connection.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the stop bits of the serial connection.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the selected port of the serial connection.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the serial output.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the selected pin.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the selected pin mode.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the selected state.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the write pin configuration.
    /// </summary>
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

    /// <summary>
    /// Gets or sets the COM object.
    /// </summary>
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

    private PresetJsonLoader _selectedPresetConfiguration;
    public PresetJsonLoader SelectedPresetConfiguration
    {
        get => _selectedPresetConfiguration;
        set
        {
            _selectedPresetConfiguration = value;
            OnPropertyChanged();
        }
    }

    private List<PresetJsonLoader> _presetConfigurations;
    public List<PresetJsonLoader> PresetConfigurations
    {
        get => _presetConfigurations;
        set
        {
            _presetConfigurations = value;
            OnPropertyChanged();
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
    public ICommand SetSelectedPresetConfigurationCommand { get; }
    public ICommand LoadConfigurationsFromFileCommand { get; }

    /// <summary>
    /// This method initializes the SerialConnectionViewViewModel.
    /// </summary>
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
        LoadConfigurationsFromFileCommand = new RelayCommand(LoadConfigurationsFromFile);
        SetSelectedPresetConfigurationCommand = new RelayCommand<PresetJsonLoader>(SetSelectedPresetConfiguration);


        // Default values
        BaudRate = 9600;
        Parity = Parity.None;
        DataBits = 8;
        StopBits = StopBits.One;

        PresetConfigurations = PresetJsonLoader.GetPresetConfigurations();
        Task.Run(ReadSerialLoop);
    }

    /// <summary>
    /// This method opens the COM connection.
    /// </summary>
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

    /// <summary>
    /// This method closes the COM connection.
    /// </summary>
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

    /// <summary>
    /// This method refreshes the pins.
    /// </summary>
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

    /// <summary>
    /// This method lists the available ports.
    /// </summary>
    private void ListPorts()
    {
        AvailablePorts.Clear();
        foreach (var port in COM.ListOpenPorts())
        {
            AvailablePorts.Add(port);
        }
    }

    /// <summary>
    /// This method adds a pin to the Pins collection.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pinMode"></param>
    /// <param name="state"></param>
    public void AddPin(int id, PinMode pinMode, State state)
    {
        var pinViewModel = new CustomPinViewModel(id, pinMode, state, _com, RemovePin);
        Pins.Add(pinViewModel);
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

    /// <summary>
    /// This method updates the pin.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="state"></param>
    /// <param name="pinMode"></param>
    public void UpdatePin(int id, State state, PinMode pinMode)
    {
        var pinViewModel = Pins.FirstOrDefault(p => p.ID == id);
        if (pinViewModel != null)
        {
            pinViewModel.UpdateState();
        }
    }

    /// <summary>
    /// This method reads the serial output in a loop.
    /// </summary>
    /// <returns> Task </returns>
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

    /// <summary>
    /// This method clears the serial output.
    /// </summary>
    public void ClearSerialOutput()
    {
        SerialOutput = string.Empty;

        if (COM != null)
        {
            COM.ClearSerialOutput();
        }
    }

    /// <summary>
    /// Writes the pin configuration.
    /// </summary>
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

    /// <summary>
    /// Parses the JSON configuration.
    /// </summary>
    /// <param name="json"></param>
    private void ParseJsonConfiguration(string json)
    {
        if (COM == null)
        {
            return;
        }

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


    /// <summary>
    /// Reads the pin configuration from the COM port.
    /// </summary>
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

    /// <summary>
    /// Loads the preset configurations.
    /// </summary>
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

    /// <summary>
    /// Loads the configurations from a file.
    /// </summary>
    private void LoadConfigurationsFromFile()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog
        {
            Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
        };

        if (openFileDialog.ShowDialog() == true)
        {
            try
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                ParseJsonConfiguration(json);
                MessageBox.Show("Configurations loaded successfully.");

                if (COM != null)
                {
                    COM.WriteSerialOutput(json);
                }
                else
                {
                    MessageBox.Show("Please open a connection first.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load configurations: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="presetConfiguration"></param>
    private void SetSelectedPresetConfiguration(PresetJsonLoader presetConfiguration)
    {
        SelectedPresetConfiguration = presetConfiguration;
    }
}