﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_WPF.Models;

/// <summary>
/// Enum for the different pin modes.
/// </summary>
public enum PinMode
{
    Input,
    Output,
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