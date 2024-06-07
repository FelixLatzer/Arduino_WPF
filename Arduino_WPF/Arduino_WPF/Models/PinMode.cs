using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_WPF.Models;

public enum PinMode
{
    Input,
    Output,
    Analog,
    PWM,
    Servo,
    Unknown
}

public enum State
{
    Low,
    High,
    Unknown
}