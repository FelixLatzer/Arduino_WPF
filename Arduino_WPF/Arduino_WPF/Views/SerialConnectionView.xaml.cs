using Arduino_WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arduino_WPF.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        // instanciate viewmodel and set the context to it
        SerialConnectionViewViewModel viewModel = new();
        this.DataContext = viewModel;
    }

    // here is the code behind
    // MVVM tries to keep this area relatively clean (DataBinding)
}