using Arduino_WPF.Models;
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
    public CustomPinViewModel viewModel;
    public CustomPin()
    {
        InitializeComponent();

        // TODO: find solution so no values are needed for ctor
        viewModel = new(0, PinMode.Input, State.Low);
        this.DataContext = viewModel;
    }
}
