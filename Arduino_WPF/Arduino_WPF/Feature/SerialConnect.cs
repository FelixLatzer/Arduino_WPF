using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduino_WPF.Feature;

public class SerialConnect
{
    public record Command
    {
        public required string ComPort { get; init; }
        public required int BaudRate { get; init; }
    }

}

