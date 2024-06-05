using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Arduino_WPF.Models;

public class Pin(int id, PinMode pinMode, State state)
{
    public int ID { get; set; } = id;
    public PinMode PinMode { get; set; } = pinMode;
    public State State { get; set; } = state;

    [JsonIgnore]
    public DateTime LastRefresh { get; set; } = DateTime.Now;

    public void WritePinData(State newState, PinMode newPinMode)
    {
        State = newState;
        LastRefresh = DateTime.Now;
        string json = JsonSerializer.Serialize(this);
    }

    // TODO: add null check!!!
    public void ReadPinData(string json)
    {
        Pin pin = JsonSerializer.Deserialize<Pin>(json);
        ID = pin.ID;
        PinMode = pin.PinMode;
        State = pin.State;
        LastRefresh = pin.LastRefresh;
    }
}
