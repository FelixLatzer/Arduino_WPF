using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_WPF.Models;

public class Pin(int id, PinMode pinMode, State state)
{
    public int ID { get; set; } = id;
    public PinMode PinMode { get; set; } = pinMode;
    public State State { get; set; } = state;
    public DateTime LastRefresh { get; set; } = DateTime.Now;

    public void UpdateState(State newState)
    {
        State = newState;
        LastRefresh = DateTime.Now;
    }
}
