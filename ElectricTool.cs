using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore
{
    public enum PowerSourceEnum
    {
        Batery,
        Cable
    }
    class ElectricTool : Tool
    {
        public PowerSourceEnum PowerSource { get; set; }
        public PowerSourceEnum ElectricCurrentType { get; set; }

    }
}
