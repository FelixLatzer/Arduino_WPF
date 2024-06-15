using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

    /// <summary>
    /// Loads the preset JSON configurations.
    /// </summary>
    /// <returns> The serialized JSON string. </returns>
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

    /// <summary>
    /// Gets the preset configurations.
    /// </summary>
    /// <returns> returns a list of preset configurations. </returns>
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

    /// <summary>
    /// Gets the preset analog configurations.
    /// </summary>
    /// <returns> returns a list of preset analog configurations. </returns>
    public static List<PresetJsonLoader> GetPresetAnalogConfigurations()
    {
        List<PresetJsonLoader> configurations = new List<PresetJsonLoader>();

        int[] analogPins = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        foreach (int pin in analogPins)
        {
            configurations.Add(new PresetJsonLoader { Id = pin, Mode = "ANALOG", State = 0 });
        }

        return configurations;
    }

    /// <summary>
    /// Loads the configurations from a file.
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns> List of preset configurations. </returns>
    public static List<PresetJsonLoader> LoadConfigurationsFromFile(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);

            List<PresetJsonLoader> configurations = JsonConvert.DeserializeObject<List<PresetJsonLoader>>(json);

            return configurations;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading configurations: {ex.Message}");
            return new List<PresetJsonLoader>();
        }
    }
}
