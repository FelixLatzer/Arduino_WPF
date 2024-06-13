﻿using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class CustomPinViewModel : BaseViewModel
{
    private readonly Pin _pin;
    private readonly Action<CustomPinViewModel> _onClickExit;
    public ObservableCollection<PinMode> PinModes { get; private set; }
    public ObservableCollection<State> PinStates { get; private set; }

    public string Titel 
    {
        get => $"Pin {_pin.ID}";
    }

    public int ID
    {
        get => _pin.ID;
        set
        {
            if (_pin.ID != value)
            {
                _pin.ID = value;
                OnPropertyChanged();
            }
        }
    }

    public PinMode PinMode
    {
        get => _pin.PinMode;
        set
        {
            if (_pin.PinMode != value)
            {
                _pin.PinMode = value;
                OnPropertyChanged();
            }
        }
    }

    public State State
    {
        get => _pin.State;
        set
        {
            if (_pin.State != value)
            {
                _pin.WritePinData(value, _pin.PinMode);
                OnPropertyChanged();
                OnPropertyChanged(nameof(LastRefresh));
            }
        }
    }

    private PinMode _selectedPinMode;
    public PinMode SelectedPinMode
    {
        get => _selectedPinMode;
        set
        {
            _selectedPinMode = value;
            OnPropertyChanged();
        }
    }

    private State _selectedState;
    public State SelectedState
    {
        get => _selectedState;
        set
        {
            _selectedState = value;
            OnPropertyChanged();
        }
    }

    public DateTime LastRefresh => _pin.LastRefresh;

    public ICommand OnClickExitButtonCommand 
    {
        get;
        set;
    }

    public CustomPinViewModel(int iD, PinMode pinMode, State state, Action<CustomPinViewModel> OnClickExitButton)
    {
        _pin = new(iD, pinMode, state);
        _onClickExit = OnClickExitButton;
        OnClickExitButtonCommand = new RelayCommand(OnClickExit);
        PinModes = new ObservableCollection<PinMode>(Enum.GetValues(typeof(PinMode)).Cast<PinMode>());
        PinStates = new ObservableCollection<State>(Enum.GetValues(typeof(State)).Cast<State>());
    }

    public void UpdateState()
    {
        // get id, current state and the current pinMode
        // if the id matches the current id, update the state and pinMode
        OnPropertyChanged(nameof(State));
        OnPropertyChanged(nameof(PinMode));
        OnPropertyChanged(nameof(LastRefresh));
    }

    private void OnClickExit()
    {
        _onClickExit(this);
    }
}
