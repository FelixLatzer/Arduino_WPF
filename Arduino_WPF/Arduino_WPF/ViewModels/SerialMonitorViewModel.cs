using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;
public class SerialMonitorViewModel : BaseViewModel
{
    private COM _com;

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

    public ICommand ClearSerialOutputCommand { get; }

    public SerialMonitorViewModel(COM com)
    {
        _com = com;
        ClearSerialOutputCommand = new RelayCommand(ClearSerialOutput);
        Task.Run(ReadSerialLoop);
    }

    /// <summary>
    /// This method reads the serial output in a loop.
    /// </summary>
    /// <returns> Task </returns>
    private async Task ReadSerialLoop()
    {
        while (true)
        {
            if (_com != null)
            {
                string output = _com.ReadSerialOutput();
                if (!string.IsNullOrEmpty(output))
                {
                    SerialOutput += output;
                    ParseJsonConfiguration(output);
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

        if (_com != null)
        {
            _com.ClearSerialOutput();
        }
    }

    /// <summary>
    /// Parses the JSON configuration.
    /// </summary>
    /// <param name="json"></param>
    private void ParseJsonConfiguration(string json)
    {
        if (_com == null)
        {
            return;
        }

        var jsonObjects = _com.ExtractJsonObjects(ref json);
        foreach (var jsonObject in jsonObjects)
        {
            if (jsonObject.ContainsKey("id") && jsonObject.ContainsKey("mode") && jsonObject.ContainsKey("state"))
            {
                int id = jsonObject["id"].Value<int>();
                PinMode pinMode = (PinMode)Enum.Parse(typeof(PinMode), jsonObject["mode"].Value<string>(), true);
                State state = (State)jsonObject["state"].Value<int>();
            }
        }
    }

    /// <summary>
    /// Reads the pin configuration from the COM port.
    /// </summary>
    private void ReadPinConfigurationFromCOM()
    {
        if (_com != null)
        {
            string data = _com.ReadSerialOutput();
            if (!string.IsNullOrEmpty(data))
            {
                ParseJsonConfiguration(data);
            }
        }
    }

    /// <summary>
    /// This method refreshes the pins.
    /// </summary>
    private void RefreshPins()
    {
        if (_com == null)
        {
            MessageBox.Show("Please open a connection first.");
            return;
        }

        var readPinConfiguration = _com.ReadPinConfiguration();
        if (!string.IsNullOrEmpty(readPinConfiguration))
        {
            ParseJsonConfiguration(readPinConfiguration);
        }
    }
}
