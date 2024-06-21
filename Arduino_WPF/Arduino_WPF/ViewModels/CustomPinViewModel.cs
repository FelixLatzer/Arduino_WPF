using Arduino_WPF.Models;
using Arduino_WPF.Utils;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Arduino_WPF.ViewModels;

public class CustomPinViewModel : BaseViewModel
{
    private readonly COM _com;
    private readonly Pin _pin;
    public ObservableCollection<PinMode> PinModes { get; private set; }
    public ObservableCollection<State> PinStates { get; private set; }

    /// <summary>
    /// This property gets the title of the pin.
    /// </summary>
    public string Titel 
    {
        get => $"Pin {_pin.Id}";
    }

    /// <summary>
    /// This property gets the text for the refresh label
    /// </summary>
    public string LastRefreshText
    {
        get => $"Last Refresh: {_pin.LastRefresh}";
    }

    /// <summary>
    /// This property gets the ID of the pin.
    /// </summary>
    public int ID
    {
        get => _pin.Id;
        set
        {
            if (_pin.Id != value)
            {
                _pin.Id = value;
                OnPropertyChanged();
            }
        }
    }

    /// <summary>
    /// This property gets the pinMode of the pin.
    /// </summary>
    public PinMode PinMode
    {
        get => _pin.Mode;
        set
        {
            if (_pin.Mode != value)
            {
                _pin.Mode = value;
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
                _pin.WritePinData(value, _pin.Mode);
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
    public ICommand OnClickExitButtonCommand { get; set; }

    /// <summary>
    /// This property gets the command for the Write pin button.
    /// </summary>
    public ICommand WritePinCommand { get; set; }

    /// <summary>
    /// Constructor for the CustomPinViewModel class.
    /// </summary>
    /// <param name="iD"></param>
    /// <param name="pinMode"></param>
    /// <param name="state"></param>
    /// <param name="OnClickExitButton"></param>
    public CustomPinViewModel(int iD, PinMode pinMode, State state, COM com, Action<object> OnClickExitButton)
    {
        _com = com;
        _pin = new(iD, pinMode, state);
        OnClickExitButtonCommand = new RelayCommandWithParameter(OnClickExitButton);
        WritePinCommand = new RelayCommand(WritePin);
        PinModes = new ObservableCollection<PinMode>(Enum.GetValues<PinMode>());
        PinStates = new ObservableCollection<State>(Enum.GetValues<State>());
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

    /// <summary>
    /// This method checks if the pinmode is input.
    /// If the pinmode is input the state cannot be selected.
    /// </summary>
    private void CheckIfPinIsInput()
    {
        if (SelectedPinMode == PinMode.Input) 
        {
            IsPinInput = false;
            return;
        }

        SelectedState = State.Unknown;
        IsPinInput = true;
    }

    /// <summary>
    /// This method writes the configured PinData to the Microcontroller.
    /// </summary>
    public void WritePin()
    {
        string pinDataJson;

        try
        {
            pinDataJson = _pin.WritePinData(SelectedState, SelectedPinMode);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            MessageBox.Show(ex.Message);
            return;
        }

        _com.WriteSerialOutput($"[{pinDataJson}]");

        OnPropertyChanged(nameof(LastRefreshText));

    }
}
