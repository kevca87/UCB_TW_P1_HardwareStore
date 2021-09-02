using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore.Models
{
    public enum PowerSourceEnum
    {
        Batery,
        Cable
    }
    class ElectricTool : Tool
    {
        public PowerSourceEnum PowerSource { get; set; }
        public int ElectricCurrentType { get; set; }
        public override string ToString()
        {
            return Name;
        }
        private string powerSourceStr()
        {
            return PowerSource == PowerSourceEnum.Batery ? "Batery" : "Cable";
        }
        public override string ShowDetail()
        {
            string ans = $"----------------------------------\n";
            ans = $"{ans}{Name}\n" +
                $"Id: {Id}\n" +
                $"Brand: {Brand}\n" +
                $"Price: {Price}\n" +
                $"Power source: {powerSourceStr()}\n" +
                $"Electric current type: {ElectricCurrentType}\n" +
                $"----------------------------------\n";
            return ans;
        }
    }
}
