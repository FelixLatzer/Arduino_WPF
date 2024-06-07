using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class CustomPinViewModel : BaseViewModel
{
    private readonly Pin _pin;

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

    public DateTime LastRefresh => _pin.LastRefresh;

    public void UpdateState(/*int id, State state, PinMode pinMode*/)
    public ICommand TogglePinModeCommand;
    public ICommand ToggleStateCommand;
    public ICommand OnClickExitButtonCommand;

    public CustomPinViewModel(int iD, PinMode pinMode, State state, Action OnClickExitButton)
    {
        // get id, current state and the current pinMode
        // if the id matches the current id, update the state and pinMode
        if (id == _pin.ID)
        {
            _pin.WritePinData(state, pinMode);
            OnPropertyChanged(nameof(State));
            OnPropertyChanged(nameof(PinMode));
            OnPropertyChanged(nameof(LastRefresh));
        }
        else
        {
            throw new Exception("ID does not match");
        }
        _pin = new(iD, pinMode, state);
        TogglePinModeCommand = new RelayCommand(TogglePinMode);
        ToggleStateCommand = new RelayCommand(ToggleState);
        OnClickExitButtonCommand = new RelayCommand(OnClickExitButton);
    }

    private void TogglePinMode()
    {
        PinMode = PinMode == PinMode.INPUT ? PinMode.OUTPUT : PinMode.INPUT;
    }

    public void ToggleState()
    {
        State = State == State.LOW ? State.HIGH : State.LOW;
    }
}
