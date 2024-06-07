using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public void OpenConnection()
    {
        if (!_serialPort.IsOpen)
        {
            _serialPort.Open();
        }
    }

    public void CloseConnection()
    {
        if (_serialPort.IsOpen)
        {
            _serialPort.Close();
        }
    }

    public static string[] ListOpenPorts()
    {
        return SerialPort.GetPortNames();
    }

    public void SetBaudrate(int baudrate)
    {
        Baudrate = baudrate;
        _serialPort.BaudRate = baudrate;
    }

    public void SetParity(Parity parity)
    {
        Parity = parity;
        _serialPort.Parity = parity;
    }

    public void SetDataBits(int dataBits)
    {
        DataBits = dataBits;
        _serialPort.DataBits = dataBits;
    }

    private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        SerialPort sp = (SerialPort)sender;
        string inData = sp.ReadExisting();
        lock (_serialBuffer)
        {
            _serialBuffer.Append(inData);
        }
    }

    public string ReadSerialOutput()
    {
        lock (_serialBuffer)
        {
            string data = _serialBuffer.ToString();
            _serialBuffer.Clear();
            return data;
        }
    }

    public void ClearSerialOutput()
    {
        lock (_serialBuffer)
        {
            _serialBuffer.Clear();
        }
    }

    public void WriteSerialOutput(string data)
    {
        _serialPort.Write(data);
    }

    public string ReadPinConfiguration()
    {
        var data = ReadSerialOutput();
        if (string.IsNullOrWhiteSpace(data))
        {
            return string.Empty;
        }
        lock (_serialBuffer)
        {
            _serialBuffer.Append(data);
        }
        return data;
    }
}

