using Inventory.Classer;
using System;
using System.Collections.Generic;

namespace Inventory
{
    internal class Print
    {
        internal char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private DataAccess _dataAccess = new DataAccess();

        internal Page PrintPage(List<MenuItems> PageMenu)
        {
            Console.WriteLine();
            Console.WriteLine("Vad vill du göra?");
            PrintMenu(PageMenu);
            Console.WriteLine();
            return MakeChoices(PageMenu);
        }

        internal void PrintHeader(string head)
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
                Console.WriteLine($"{i}. {types[i].Beskrivning}");
            }
            Console.WriteLine();
            Console.WriteLine("Välj vilken typ");
            int x = int.Parse(Console.ReadLine());
            return types[x].Id;
        }

        internal int PrintSubTypes(int choosenType)
        {
            List<SubTyp> subTypes = _dataAccess.GetAllSubTyps(choosenType);
            for (int i = 0; i < subTypes.Count; i++)
            {
                Console.WriteLine($"{i}. {subTypes[i].Namn}");

            }
            Console.WriteLine();
            Console.WriteLine("Välj vilken typ");
            int x = int.Parse(Console.ReadLine());
            return subTypes[x].Id;

        }

        internal List<Vara> PrintAllItemsOfAType(int choosenType)
        {
           List<Vara> x = _dataAccess.GetAllVaraOfTyp(choosenType);
            foreach (Vara item in x)
            {
                Console.WriteLine(item.Id.ToString().PadRight(10)+item.TypNamn.PadRight(10)+ item.SubTypNamn.PadRight(10)+ item.StatusId);
                Console.WriteLine();

                Console.WriteLine(item.Beskrivning);
                Console.WriteLine();

                Console.WriteLine(item.Pris.ToString().PadRight(8) + item.DatumInköpt);
                Console.WriteLine();
                Console.WriteLine();

            }
            return x;

        }

        internal void PrintAllItemsOfASubType(int choosenSubTyp, List<Vara> valdaVaror)
        {
            List<Vara> subtypVara = new List<Vara>();
            foreach (Vara item in valdaVaror)
            {
                if (item.SubTypId == choosenSubTyp)
                {
                    subtypVara.Add(item);
                }
            }

            foreach (Vara item in subtypVara)
            {
                Console.WriteLine(item.Id.ToString().PadRight(10) + item.TypNamn.PadRight(10) + item.SubTypNamn.PadRight(10) + item.StatusId);
                Console.WriteLine();
                Console.WriteLine(item.Beskrivning);
                Console.WriteLine();

                Console.WriteLine(item.Pris.ToString().PadRight(8) + item.DatumInköpt);
                Console.WriteLine();
                Console.WriteLine();

            }

            Console.ReadLine();

        }
    }
}