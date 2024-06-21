using Arduino_WPF.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_WPF.Utils;
public class SerialReader : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// This method is called when a property is changed.
    /// </summary>
    /// <param name="propertyName"></param>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private COM _com;

    private Pin _lastReceivedPinConfig;
    public Pin LastReceivedPinConfig
    {
        get => _lastReceivedPinConfig;
        set
        {
            _lastReceivedPinConfig = value;
            OnPropertyChanged();
        }
    }

    private string _serialOutput;
    public string SerialOutput
    {
        get => _serialOutput;
        set
        {
            _serialOutput = value;
            OnPropertyChanged();
        }
    }

    public SerialReader(COM com)
    {
        _com = com;
    }

    /// <summary>
    /// This method reads the serial output in a loop.
    /// </summary>
    /// <returns> Task </returns>
    public async Task ReadSerialLoop()
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
            if (jsonObject.ContainsKey("Id") && jsonObject.ContainsKey("Mode") && jsonObject.ContainsKey("State"))
            {
                int id = jsonObject["Id"].Value<int>();
                PinMode pinMode = (PinMode)Enum.Parse(typeof(PinMode), jsonObject["Mode"].Value<string>(), true);
                State state = (State)jsonObject["State"].Value<int>();

                LastReceivedPinConfig = new Pin(id, pinMode, state);
            }
        }
    }
}
