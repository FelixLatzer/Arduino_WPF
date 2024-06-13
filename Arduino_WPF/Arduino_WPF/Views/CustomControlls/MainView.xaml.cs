﻿using Arduino_WPF.ViewModels;
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
/// Interaction logic for MainView.xaml
/// </summary>
public partial class MainView : UserControl
{
    public MainViewViewModel ViewModel { get; set; }

    public MainView()
    {
        InitializeComponent();

        ViewModel = new();
        this.DataContext = ViewModel;
    }
}