using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChargeStationClassLibrary.Display
{
    public class Display : IDisplay
    {
        public void PrintString(string text)
        {
            Console.WriteLine(text);
        }
    }
}
