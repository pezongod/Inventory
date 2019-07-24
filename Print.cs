using System;
using System.Collections.Generic;

namespace Inventory
{
    internal class Print
    {
        internal char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        internal Page PrintPage(string head, List<MenuItems> PageMenu)
        {
            PrintHeader(head);
            Console.WriteLine();
            Console.WriteLine("Vad vill du göra?");
            PrintMenu(PageMenu);
            Console.WriteLine();
            return MakeChoices(PageMenu);
        }

        private void PrintHeader(string head)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(head);
            Console.ResetColor();
        }

        private void PrintMenu(List<MenuItems> PageMenu)
        {
            for (int i = 0; i < PageMenu.Count; i++)
            {
                Console.WriteLine($"{alphabet[i]}) {PageMenu[i].Name}");
            }
        }

        private Page MakeChoices(List<MenuItems> pageMenu)
        {
            Page x = Page.Main;
            var choice = Console.ReadKey();
            Console.WriteLine();

            for (int i = 0; i < pageMenu.Count; i++)
            {
                if (choice.KeyChar == alphabet[i])
                {
                    x = pageMenu[i].Connection;
                }
            }
            return x;
        }

        internal int PrintTypes()
        {
            List<Typ> types = _dataAccess.GetAllTyps();
            for (int i = 0; i < types.Count; i++)
            {
                Console.WriteLine($"{i}. {types[i].Namn}");
            }
            Console.WriteLine();
            Console.WriteLine("Välj vilken typ av objekt du vill lägga till");
            return int.Parse(Console.ReadLine());
        }

        internal int PrintSubTypes()
        {
            List<SubTyp> subTypes = GetAllSubTyps(choosenType);
            for (int i = 0; i < subTypes.Count; i++)
            {
                Console.WriteLine($"{i}. {subTypes[i].Name}");

            }
            Console.WriteLine();
            Console.WriteLine("Välj vilken typ av objekt du vill lägga till");
            int x = int.Parse(Console.ReadLine());
            return subTypes[x].Id;

        }
    }
}