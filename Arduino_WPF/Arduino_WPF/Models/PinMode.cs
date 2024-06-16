using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace Arduino_WPF.Models;

/// <summary>
/// Enum for the different pin modes.
/// </summary>
public enum PinMode
{
    Input,
    Output,
    Input_Pullup,
    Analog,
    PWM,
    Servo,
    Unknown
}

/// <summary>
/// Enum for the different pin states.
/// </summary>
public enum State
{
    Low,
    High,
    Unknown
}