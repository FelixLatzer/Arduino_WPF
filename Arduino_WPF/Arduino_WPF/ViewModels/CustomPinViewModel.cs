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

    public void UpdateState()
    {
        // TODO: JUST A TRYOUT REPLACE WITH ACTUAL LOGIC!!!!
        State = State == State.Low ? State.High : State.Low;
    }
}
