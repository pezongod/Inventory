using System;
using System.Collections.Generic;

namespace Inventory
{
    internal class Print
    {
        public Print()
        {
        }

        internal void PrintPage(string head, List<MenuItems> PageMenu)
        {
            PrintHeader(head);
            Console.WriteLine("Vad vill du göra?");
            PrintMenu(PageMenu);
            MakeChoices(PageMenu);
            
        }


        private void PrintHeader(string head)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(head);
            Console.ResetColor();
        }
        private void PrintMenu(List<MenuItems> PageMenu)
        {
            foreach (MenuItems item in PageMenu)
            {
                Console.WriteLine($"item.Name);
            }
        }
        private void MakeChoices(List<MenuItems> pageMenu)
        {
            throw new NotImplementedException();
        }

    }
}