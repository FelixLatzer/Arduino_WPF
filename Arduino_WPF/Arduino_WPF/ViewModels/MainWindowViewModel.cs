using Arduino_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    public ICommand ShowComConfigurationViewCommand { get; set; }
    public ICommand ShowPinViewCommand { get; set; }

    private SerialConnectionViewViewModel _serialConnectionViewViewModel {  get; set; }
    private PinViewViewModel _pinViewModel {  get; set; }


    private object _selectedViewModel;
    public object SelectedViewModel
    {
        get => _selectedViewModel;

        set 
        {
            if (_selectedViewModel != value)
            {
                _selectedViewModel = value;
                OnPropertyChanged();
            }
        }
    }


    public MainWindowViewModel()
    {
        ShowComConfigurationViewCommand = new RelayCommand(ShowSerialConnectionView);
        ShowPinViewCommand = new RelayCommand(ShowPinView);
        _serialConnectionViewViewModel = new SerialConnectionViewViewModel();
        SelectedViewModel = _serialConnectionViewViewModel;
    }

    private void ShowSerialConnectionView()
    {
        SelectedViewModel = _serialConnectionViewViewModel;
    }

    private void ShowPinView()
    {
        SelectedViewModel = new PinViewViewModel(_serialConnectionViewViewModel.COM);
    }
}

