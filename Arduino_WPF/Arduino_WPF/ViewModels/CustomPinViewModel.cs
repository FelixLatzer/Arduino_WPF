using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class CustomPinViewModel : BaseViewModel
{
    private int _id;
    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
            OnPropertyChanged();
        }
    }

    private int _idCopy;
    public int IdCopy
    {
        get
        {
            return _idCopy;
        }
        set
        {
            _idCopy = value;
            Id = value;
            OnPropertyChanged();
        }
    }

    private PinMode _pinMode;
    public PinMode PinMode 
    { 
        get
        {
            return _pinMode;
        }
        set
        {
            _pinMode = value;
            OnPropertyChanged();
        }
    }
    public State State { get; set; }
    public ICommand TogglePinModeCommand { get; set; }

    private readonly Pin _pin;

    CustomPinViewModel() { }

    public CustomPinViewModel(int id, PinMode pinMode, State state)
    {
        _pin = new(id, pinMode, state);
        TogglePinModeCommand = new RelayCommand(TogglePinMode);
    }
    
    public DateTime LastRefresh => _pin.LastRefresh;

    private void TogglePinMode()
    {
        PinMode = PinMode == PinMode.OUTPUT ? PinMode.INPUT : PinMode.OUTPUT;
    }

    public void UpdateState()
    {
        // TODO: JUST A TRYOUT REPLACE WITH ACTUAL LOGIC!!!!
        State = State == State.LOW ? State.HIGH : State.LOW;
    }
}
