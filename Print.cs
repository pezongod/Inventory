using System;

namespace Inventory
{
    internal class Print
    {
        public Print()
        {
        }

        internal void PrintPage()
        {
            PrintHeader(title);
            PrintMenu();
            MakeChoices();
        }
    }
}