using System;
using System.Collections.Generic;
using System.Text;

namespace HumidityFanApp.Models
{
    public enum MenuItemType
    {
        
         Settings,
        Browse
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
