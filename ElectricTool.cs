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
        public override string ToString()
        {
            return Name;
        }
        public virtual string Show()
        {
            string ans = base.Show();
            ans = $"Power Source: {PowerSource}\n" +
                $"Electric current type: {ElectricCurrentType}\n";
            return ans;
        }
    }
}
