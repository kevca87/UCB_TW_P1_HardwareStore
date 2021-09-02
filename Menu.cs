using HardwareStore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardwareStore
{

    public delegate void UIFunction(Cart<IProduct> cart);
    class Menu<OptionT>
    {
        public string Name { get; set; }
        //TO DO (OptionT,Name)
        Dictionary<OptionT,(string FunName,UIFunction Fun)> _uIFunctions = new Dictionary<OptionT, (string, UIFunction)>();
        public void AddOption(OptionT newOption,string optionName,UIFunction uIFunction)
        {
            if (!_uIFunctions.ContainsKey(newOption))
            {
                _uIFunctions.Add(newOption, (optionName,uIFunction));
            }
        }
        public UIFunction ChooseOption(OptionT option)
        {
            (string FunName,UIFunction Fun) uIFun;
            bool allOk = _uIFunctions.TryGetValue(option, out uIFun);
            if (!allOk)
            {
                throw new Exception("That option does'nt exist, choose another  : v");
            }
            return uIFun.Fun;
        }
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{Name}\n");
            foreach (var optFunc in _uIFunctions)
            {
                Console.WriteLine($"{optFunc.Key}) {optFunc.Value.FunName}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
