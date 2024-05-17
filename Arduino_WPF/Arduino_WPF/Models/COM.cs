using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_WPF.Models;

public class COM(int baudrate, string port, Parity parity, int dataBits, StopBits stopBits)
{
    public int Baudrate { get; set; } = baudrate;
    public string Port { get; set; } = port;
    private SerialPort SerialPort { get; set; } = new SerialPort(port, baudrate, parity, dataBits, stopBits);
    public Parity Parity { get; set; } = parity;
    public int DataBits { get; set; } = dataBits;
    public StopBits StopBits { get; set; } = stopBits;

    public void OpenConnection()
    {
        if (!SerialPort.IsOpen)
        {
            SerialPort.Open();
        }
    }

    public void CloseConnection()
    {
        if (SerialPort.IsOpen)
        {
            SerialPort.Close();
        }
    }
}
