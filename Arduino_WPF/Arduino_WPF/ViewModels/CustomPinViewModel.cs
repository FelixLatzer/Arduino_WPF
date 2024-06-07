using Arduino_WPF.Models;
using Arduino_WPF.Utils;
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

    public ICommand TogglePinModeCommand;
    public ICommand ToggleStateCommand;
    public ICommand OnClickExitButtonCommand;

    // temporary solution for CodeBehind problem --> see customPin.xaml.cs
    public CustomPinViewModel(int iD, PinMode pinMode, State state)
    {
        _pin = new(iD, pinMode, state);
        TogglePinModeCommand = new RelayCommand(TogglePinMode);
        ToggleStateCommand = new RelayCommand(ToggleState);
        OnClickExitButtonCommand = new RelayCommand(TogglePinMode); // !!!!!!!!
    }

    public CustomPinViewModel(int iD, PinMode pinMode, State state, Action OnClickExitButton)
    {
        _pin = new(iD, pinMode, state);
        TogglePinModeCommand = new RelayCommand(TogglePinMode);
        ToggleStateCommand = new RelayCommand(ToggleState);
        OnClickExitButtonCommand = new RelayCommand(OnClickExitButton);
    }

    public void UpdateState(/*int id, State state, PinMode pinMode*/)
    {
        // get id, current state and the current pinMode
        // if the id matches the current id, update the state and pinMode
        //if (id == _pin.ID)
        //{
        //    _pin.WritePinData(state, pinMode);
        //    OnPropertyChanged(nameof(State));
        //    OnPropertyChanged(nameof(PinMode));
        //    OnPropertyChanged(nameof(LastRefresh));
        //}
        //else
        //{
        //    throw new Exception("ID does not match");
        //}
    }

    private void TogglePinMode()
    {
        PinMode = PinMode == PinMode.Input ? PinMode.Input : PinMode.Input;
    }

    public void ToggleState()
    {
        State = State == State.Low ? State.Low : State.Low;
    }
}
