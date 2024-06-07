using Arduino_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_WPF.ViewModels;

public class CustomPinViewModel(int id, PinMode pinMode, State state) : BaseViewModel
{
    private readonly Pin _pin = new(id, pinMode, state);

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
    }
}
