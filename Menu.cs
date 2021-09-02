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
        Dictionary<OptionT,UIFunction> _uIFunctions = new Dictionary<OptionT, UIFunction>();
        public void AddOption(OptionT newOption,UIFunction uIFunction)
        {
            if (!_uIFunctions.ContainsKey(newOption))
            {
                _uIFunctions.Add(newOption, uIFunction);
            }
        }
        public UIFunction ChooseOption(OptionT option)
        {
            UIFunction fun;
            bool allOk = _uIFunctions.TryGetValue(option, out fun);
            if (!allOk)
            {
                throw new Exception("That option does'nt exist, choose another  : v");
            }
            return fun;
        }
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{Name}\n");
            foreach (var optFunc in _uIFunctions)
            {
                Console.WriteLine($"{optFunc.Key}) {optFunc.Value.Method.Name}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
