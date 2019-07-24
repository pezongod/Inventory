using System;
using System.Collections.Generic;

namespace Inventory
{
    internal class Print
    {
        public Print()
        {
        }

        internal void PrintPage(List<MenuItems> mainPageMenu)
        {
            PrintHeader(title);
            PrintMenu();
            MakeChoices();
        }
    }
}