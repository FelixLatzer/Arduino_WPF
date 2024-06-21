using Arduino_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        if (_serialConnectionViewViewModel.SerialReader is null)
        {
            MessageBox.Show("Open com first");
            return;
        }
        if (_pinViewModel is null)
        {
            _pinViewModel = new PinViewViewModel(_serialConnectionViewViewModel.COM, _serialConnectionViewViewModel.SerialReader);
        }

        SelectedViewModel = _pinViewModel;
        _pinViewModel.COM = _serialConnectionViewViewModel.COM;
    }
}

