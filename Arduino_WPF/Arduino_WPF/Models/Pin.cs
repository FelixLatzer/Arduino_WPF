using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Arduino_WPF.Models
{
    public class Pin
    {
        public int ID { get; set; }
        public PinMode PinMode { get; set; }
        public State State { get; set; }
        [JsonIgnore]
        public DateTime LastRefresh { get; set; }

        public Pin(int id, PinMode pinMode, State state)
        {
            ID = id;
            PinMode = pinMode;
            State = state;
            LastRefresh = DateTime.Now;
        }

        public string WritePinData(State newState, PinMode newPinMode)
        {
            if (newState == State.Unknown)
            {
                throw new ArgumentNullException(nameof(newState), "newState cannot be null");
            }
            if (newPinMode == PinMode.Unknown)
            {
                throw new ArgumentNullException(nameof(newPinMode), "newPinMode cannot be null");
            }

            State = newState;
            PinMode = newPinMode;
            LastRefresh = DateTime.Now;
            string json = JsonSerializer.Serialize(this);

            return json;
        }

        public void ReadPinData(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentNullException(nameof(json), "json cannot be null or empty");
            }

            Pin pin = JsonSerializer.Deserialize<Pin>(json);
            if (pin != null)
            {
                ID = pin.ID;
                PinMode = pin.PinMode;
                State = pin.State;
                LastRefresh = pin.LastRefresh;
            }
        }
    }
}
