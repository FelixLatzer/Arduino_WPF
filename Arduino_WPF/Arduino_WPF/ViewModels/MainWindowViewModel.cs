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


    /// <summary>
    /// This is the getter and setter of the SelectedViewModel property.
    /// </summary>
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

    /// <summary>
    /// This is the constructor of the MainWindowViewModel class.
    /// </summary>
    public MainWindowViewModel()
    {
        ShowComConfigurationViewCommand = new RelayCommand(ShowSerialConnectionView);
        ShowPinViewCommand = new RelayCommand(ShowPinView);
        _serialConnectionViewViewModel = new SerialConnectionViewViewModel();
        SelectedViewModel = _serialConnectionViewViewModel;
    }

    /// <summary>
    /// This method shows the serial connection view.
    /// </summary>
    private void ShowSerialConnectionView()
    {
        SelectedViewModel = _serialConnectionViewViewModel;
    }

    /// <summary>
    /// This method shows the pin view.
    /// </summary>
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

