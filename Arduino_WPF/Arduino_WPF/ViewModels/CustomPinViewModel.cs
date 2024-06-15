using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class CustomPinViewModel : BaseViewModel
{
    private readonly Pin _pin;
    public ObservableCollection<PinMode> PinModes { get; private set; }
    public ObservableCollection<State> PinStates { get; private set; }

    /// <summary>
    /// This property gets the title of the pin.
    /// </summary>
    public string Titel 
    {
        get => $"Pin {_pin.ID}";
    }

    /// <summary>
    /// This property gets the ID of the pin.
    /// </summary>
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

    /// <summary>
    /// This property gets the pinMode of the pin.
    /// </summary>
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

    /// <summary>
    /// This property gets the state of the pin.
    /// </summary>
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

    /// <summary>
    /// This property gets the selected pinMode.
    /// </summary>
    private PinMode _selectedPinMode;
    public PinMode SelectedPinMode
    {
        get => _selectedPinMode;
        set
        {
            _selectedPinMode = value;
            CheckIfPinIsInput();
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// This property gets the selected state.
    /// </summary>
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

    private bool _isPinInput;
    public bool IsPinInput
    {
        get => _isPinInput;
        set
        {
            _isPinInput = value;
            OnPropertyChanged();
        }
    }

    /// <summary>
    /// This property gets the last refresh of the pin.
    /// </summary>
    public DateTime LastRefresh => _pin.LastRefresh;

    /// <summary>
    /// This property gets the command for the exit button.
    /// </summary>
    public ICommand OnClickExitButtonCommand 
    {
        get;
        set;
    }

    /// <summary>
    /// Constructor for the CustomPinViewModel class.
    /// </summary>
    /// <param name="iD"></param>
    /// <param name="pinMode"></param>
    /// <param name="state"></param>
    /// <param name="OnClickExitButton"></param>
    public CustomPinViewModel(int iD, PinMode pinMode, State state, Action<object> OnClickExitButton)
    {
        _pin = new(iD, pinMode, state);
        OnClickExitButtonCommand = new RelayCommandWithParameter(OnClickExitButton);
        PinModes = new ObservableCollection<PinMode>(Enum.GetValues(typeof(PinMode)).Cast<PinMode>());
        PinStates = new ObservableCollection<State>(Enum.GetValues(typeof(State)).Cast<State>());
        CheckIfPinIsInput();
    }

    /// <summary>
    /// This method updates the state of the pin.
    /// </summary>
    public void UpdateState()
    {
        // get id, current state and the current pinMode
        // if the id matches the current id, update the state and pinMode
        OnPropertyChanged(nameof(State));
        OnPropertyChanged(nameof(PinMode));
        OnPropertyChanged(nameof(LastRefresh));
    }

    private void CheckIfPinIsInput()
    {
        if (SelectedPinMode == PinMode.Input) 
        {
            IsPinInput = false;
            return;
        }

        IsPinInput = true;
    }
}
