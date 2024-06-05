﻿using Arduino_WPF.Models;
using Arduino_WPF.ViewModels;
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
    public required int Id { get; init; }
    private PinMode _pinMode = PinMode.INPUT;
    private State _state = State.LOW;

    public CustomPin()
    {
        InitializeComponent();

        var viewModel = new CustomPinViewModel(Id, _pinMode, _state);
        this.DataContext = viewModel;
    }
}
