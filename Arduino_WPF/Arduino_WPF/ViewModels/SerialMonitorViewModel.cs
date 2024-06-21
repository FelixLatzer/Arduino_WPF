using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;
public class SerialMonitorViewModel : BaseViewModel
{
    private COM _com;
    private SerialReader _reader;

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
    public ICommand CopyResultToClipboardCommand { get; }

    public SerialMonitorViewModel(COM com, SerialReader serialReader)
    {
        _com = com;
        _reader = serialReader;
        _reader.PropertyChanged += SerialReaderPropertyChanged;
        ClearSerialOutputCommand = new RelayCommand(ClearSerialOutput);
        CopyResultToClipboardCommand = new RelayCommand(CopyResultToClipboard);
        
    }

    public void SerialReaderPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_reader.SerialOutput))
        {
            SerialOutput = _reader.SerialOutput;
        }
    }

    /// <summary>
    /// This method clears the serial output.
    /// </summary>
    public void ClearSerialOutput()
    {
        _reader.SerialOutput = string.Empty;

        if (_com != null)
        {
            _com.ClearSerialOutput();
        }
    }

    /// <summary>
    /// This method copies the result to the clipboard.
    /// </summary>
    public void CopyResultToClipboard()
    {
        if (!string.IsNullOrEmpty(SerialOutput))
        {
            Clipboard.SetText(SerialOutput);
        }
        else
        {
            MessageBox.Show("No data to copy.");
        }
    }

    ///// <summary>
    ///// Reads the pin configuration from the COM port.
    ///// </summary>
    //private void ReadPinConfigurationFromCOM()
    //{
    //    if (_com != null)
    //    {
    //        string data = _com.ReadSerialOutput();
    //        if (!string.IsNullOrEmpty(data))
    //        {
    //            ParseJsonConfiguration(data);
    //        }
    //    }
    //}

    ///// <summary>
    ///// This method refreshes the pins.
    ///// </summary>
    //private void RefreshPins()
    //{
    //    if (_com == null)
    //    {
    //        MessageBox.Show("Please open a connection first.");
    //        return;
    //    }

    //    var readPinConfiguration = _com.ReadPinConfiguration();
    //    if (!string.IsNullOrEmpty(readPinConfiguration))
    //    {
    //        ParseJsonConfiguration(readPinConfiguration);
    //    }
    //}
}
