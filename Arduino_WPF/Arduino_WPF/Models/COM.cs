using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Arduino_WPF.Models;

public class COM
{
    private SerialPort _serialPort;
    private StringBuilder _serialBuffer = new StringBuilder();

    public int Baudrate { get; set; }
    public string Port { get; set; }
    public Parity Parity { get; set; }
    public int DataBits { get; set; }
    public StopBits StopBits { get; set; }

    /// <summary>
    /// Constructor for the COM class.
    /// </summary>
    /// <param name="baudrate"></param>
    /// <param name="port"></param>
    /// <param name="parity"></param>
    /// <param name="dataBits"></param>
    /// <param name="stopBits"></param>
    public COM(int baudrate, string port, Parity parity, int dataBits, StopBits stopBits)
    {
        Baudrate = baudrate;
        Port = port;
        Parity = parity;
        DataBits = dataBits;
        StopBits = stopBits;
        _serialPort = new SerialPort(port, baudrate, parity, dataBits, stopBits);
        _serialPort.DataReceived += DataReceivedHandler;
    }

    /// <summary>
    /// Opens the connection to the serial port.
    /// </summary>
    public void OpenConnection()
    {
        if (!_serialPort.IsOpen)
        {
            _serialPort.Open();
        }
    }

    /// <summary>
    /// Closes the connection to the serial port.
    /// </summary>
    public void CloseConnection()
    {
        if (_serialPort.IsOpen)
        {
            _serialPort.Close();
        }
    }

    /// <summary>
    /// Lists the open ports.
    /// </summary>
    /// <returns></returns>
    public static string[] ListOpenPorts()
    {
        return SerialPort.GetPortNames();
    }

    /// <summary>
    /// This method sets the port of the serial port.
    /// </summary>
    /// <param name="baudrate"></param>
    public void SetBaudrate(int baudrate)
    {
        Baudrate = baudrate;
        _serialPort.BaudRate = baudrate;
    }

    /// <summary>
    /// This method sets the parity of the serial port.
    /// </summary>
    /// <param name="parity"></param>
    public void SetParity(Parity parity)
    {
        Parity = parity;
        _serialPort.Parity = parity;
    }

    /// <summary>
    /// This method sets the data bits of the serial port.
    /// </summary>
    /// <param name="dataBits"></param>
    public void SetDataBits(int dataBits)
    {
        DataBits = dataBits;
        _serialPort.DataBits = dataBits;
    }

    /// <summary>
    /// This method is called when data is received from the serial port.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string inData = sp.ReadExisting();
        lock (_serialBuffer)
        {
            _serialBuffer.Append(inData);
        }
    }

    /// <summary>
    /// Reads the serial buffer and returns it as a string.
    /// </summary>
    /// <returns> Serial buffer as a string </returns>
    public string ReadSerialOutput()
    {
        lock (_serialBuffer)
        {
            string data = _serialBuffer.ToString();
            _serialBuffer.Clear();
            return data;
        }
    }

    /// <summary>
    /// Clears the serial buffer.
    /// </summary>
    public void ClearSerialOutput()
    {
        lock (_serialBuffer)
        {
            _serialBuffer.Clear();
        }
    }

    /// <summary>
    /// Writes data to the serial port.
    /// </summary>
    /// <param name="data"></param>
    public void WriteSerialOutput(string data)
    {
        lock (_serialBuffer)
        {    
            _serialPort.Write(data);
        }
    }

    /// <summary>
    /// Reads the pin configuration from the serial buffer and returns it as a string.
    /// </summary>
    /// <returns> Pin configuration as a string </returns>
    public string ReadPinConfiguration()
    {
        lock (_serialBuffer)
        {
            string data = _serialBuffer.ToString();
            _serialBuffer.Clear();
            return data;
        }
    }

    /// <summary>
    /// This method extracts JSON objects from a string and returns them as a list of JObjects.
    /// </summary>
    /// <param name="data"></param>
    /// <returns> List of JObjects </returns>
    public List<JObject> ExtractJsonObjects(ref string data)
    {
        var jsonObjects = new List<JObject>();
        int startIndex, endIndex;

        while ((startIndex = data.IndexOf("{")) != -1 && (endIndex = data.IndexOf("}", startIndex)) != -1)
        {
            endIndex += 1;
            string jsonSubstring = data.Substring(startIndex, endIndex - startIndex);
            data = data.Remove(startIndex, endIndex - startIndex);

            try
            {
                var jsonObject = JObject.Parse(jsonSubstring);
                jsonObjects.Add(jsonObject);
            }
            catch (JsonReaderException)
            {
                MessageBox.Show("Invalid JSON data received: " + jsonSubstring);
            }
        }

        return jsonObjects;
    }
}

