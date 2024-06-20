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
using System.Windows.Shapes;

namespace Arduino_WPF.Views;
/// <summary>
/// Interaction logic for SerialMonitorWinodw.xaml
/// </summary>
public partial class SerialMonitorWindow : Window
{
    public SerialMonitorWindow(COM com)
    {
        InitializeComponent();

        DataContext = new SerialMonitorViewModel(com);
    }
}
