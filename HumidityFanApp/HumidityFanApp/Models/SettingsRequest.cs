using System;
using System.Collections.Generic;
using System.Text;

namespace HumidityFanApp.Models
{
    public class SettingsRequest
    {
        public int temp_threshold { get; set; }
        public int humidity_threshold { get; set; }
    }
}
