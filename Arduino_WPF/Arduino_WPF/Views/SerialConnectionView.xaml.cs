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

namespace Arduino_WPF;

/// <summary>
/// Interaction logic for SerialConnectionView_1.xaml
/// </summary>
public partial class SerialConnectionView : UserControl
{
    public SerialConnectionView()
    {
        InitializeComponent();

        // instanciate viewmodel and set the context to it
        SerialConnectionViewViewModel viewModel = new();
        this.DataContext = viewModel;
    }

    // here is the code behind
    // MVVM tries to keep this area relatively clean (DataBinding)
}
