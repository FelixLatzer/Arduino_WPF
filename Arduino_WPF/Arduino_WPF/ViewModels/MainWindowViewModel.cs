using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    ICommand ShowComConfigurationViewCommand { get; set; }
    ICommand ShowPinViewCommand { get; set; }
}
