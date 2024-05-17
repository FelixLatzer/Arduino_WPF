﻿using Arduino_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arduino_WPF.Views.CustomControlls;
/// <summary>
/// Interaction logic for CustomPin.xaml
/// </summary>
public partial class CustomPin : UserControl
{
    public string zipfl { get; set; }

    public CustomPin()
    {
        InitializeComponent();

        TextBoxPinMode.Text = PinMode.INPUT.ToString();
    }

    private void ButtonTogglePinMode_Click(object sender, RoutedEventArgs e)
    {
        if(TextBoxPinMode.Text == PinMode.INPUT.ToString())
        {
            TextBoxPinMode.Text = PinMode.OUTPUT.ToString();
            return;
        }

        TextBoxPinMode.Text = PinMode.INPUT.ToString();

        zipfl = TextBoxPinMode.Text;
    }
}
