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
using Arduino_WPF.Views;

namespace Arduino_WPF.ViewModels;

public class SerialConnectionViewViewModel : BaseViewModel
{
    public ObservableCollection<string> AvailablePorts { get; private set; }

    public SerialReader SerialReader;

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
    private COM _com;
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
    public ICommand ListPortsCommand { get; }
    public ICommand ShowSerialMonitorCommand { get; }
    public ObservableCollection<Parity> ParityValues { get; private set; }
    public ObservableCollection<StopBits> StopBitsValues { get; private set; }
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
        AvailablePorts = new ObservableCollection<string>();
        OpenCOMCommand = new RelayCommand(OpenCOM);
        CloseCOMCommand = new RelayCommand(CloseCOM);
        ListPortsCommand = new RelayCommand(ListPorts);
        ShowSerialMonitorCommand = new RelayCommandWithParameter(OpenSerialMonitor);
        LoadPresetConfigurationsCommand = new RelayCommand(LoadPresetConfigurations);
        LoadConfigurationsFromFileCommand = new RelayCommand(LoadConfigurationsFromFile);
        SetSelectedPresetConfigurationCommand = new RelayCommand<PresetJsonLoader>(SetSelectedPresetConfiguration);


        // Default values
        BaudRate = 9600;
        Parity = Parity.None;
        DataBits = 8;
        StopBits = StopBits.One;

        PresetConfigurations = PresetJsonLoader.GetPresetConfigurations();
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
                SerialReader = new SerialReader(COM);
                Task.Run(SerialReader.ReadSerialLoop);
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

    private void OpenSerialMonitor(object parameter)
    {
        if (COM is null)
        {
            MessageBox.Show("Open com first!");
            return;
        }
        var serialMonitor = new SerialMonitorWindow(parameter as COM, SerialReader);
        serialMonitor.Show();
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
    /// This method sets the selected preset configuration.
    /// </summary>
    /// <param name="presetConfiguration"></param>
    private void SetSelectedPresetConfiguration(PresetJsonLoader presetConfiguration)
    {
        SelectedPresetConfiguration = presetConfiguration;
    }
}