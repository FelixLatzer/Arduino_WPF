using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Arduino_WPF.Utils;

public class PresetJsonLoader 
{
    public int Id { get; set; }
    public string Mode { get; set; }
    public int State { get; set; }

    static public string LoadPresetJsonConfigurations()
    {
        List<PresetJsonLoader> configurations = new List<PresetJsonLoader>();

        int[] digitalPins = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        foreach (int pin in digitalPins)
        {
            configurations.Add(new PresetJsonLoader { Id = pin, Mode = "OUTPUT", State = 0 });
            configurations.Add(new PresetJsonLoader { Id = pin, Mode = "OUTPUT", State = 1 });

            configurations.Add(new PresetJsonLoader { Id = pin, Mode = "INPUT", State = 0 });
        }

        return JsonConvert.SerializeObject(configurations);
    }

    public static List<PresetJsonLoader> GetPresetConfigurations()
    {
        List<PresetJsonLoader> configurations = new List<PresetJsonLoader>();

        int[] digitalPins = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

        foreach (int pin in digitalPins)
        {
            configurations.Add(new PresetJsonLoader { Id = pin, Mode = "OUTPUT", State = 0 });
            configurations.Add(new PresetJsonLoader { Id = pin, Mode = "OUTPUT", State = 1 });
            configurations.Add(new PresetJsonLoader { Id = pin, Mode = "INPUT", State = 0 });
        }

        return configurations;
    }
}
