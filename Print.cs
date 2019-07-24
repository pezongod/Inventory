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
            for (int i = 0; i < length; i++)
            {

            }
            {
                Console.WriteLine($"{alpha{item.Name}");
            }
        }
        private void MakeChoices(List<MenuItems> pageMenu)
        {
            throw new NotImplementedException();
        }

    }
}