using Inventory.Classer;
using System;
using System.Collections.Generic;

namespace Inventory
{
    internal class Print
    {
        internal char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        private DataAccess _dataAccess = new DataAccess();

        internal Page PrintPage(List<string> menu, List<Page> menuTriggers, string question)
        {
            List<MenuItems> PageMenu = PrintPageSetup(menu, menuTriggers);
            Console.WriteLine();
            Console.WriteLine(question);
            PrintMenu(PageMenu);
            Console.WriteLine();
            return MakeChoices(PageMenu);
        }

        private List<MenuItems> PrintPageSetup(List<string> menu, List<Page> menuTriggers)
        {
            List<MenuItems> p = new List<MenuItems>();
            for (int i = 0; i < menu.Count; i++)
            {
                MenuItems x = new MenuItems(menu[i], menuTriggers[i]);
                p.Add(x);
            }
            return p;
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
            List<IEntity> types = _dataAccess.GetAllTyps();
            var p = TypeChooser(types);
            return p.Id;
        }

        internal int PrintSubTypes(int choosenType)
        {
            List<IEntity> subTypes = _dataAccess.GetAllSubTyps(choosenType);
            var p = TypeChooser(subTypes);
            return p.Id;
        }

        private IEntity TypeChooser(List<IEntity> type)
        {
            for (int i = 0; i < type.Count; i++)
            {
                Console.WriteLine($"{i}. {type[i].Namn}");
            }
            Console.WriteLine();
            Console.WriteLine("Välj vilken");
            int x = int.Parse(Console.ReadLine());
            return type[x];
        }

        internal Page PrintSubtypeItems(int choosenType, List<Vara> valdaVaror)
        {
            Console.Clear();
            int choosenSubType = PrintSubTypes(choosenType);
            PrintAllItemsOfASubType(choosenSubType, valdaVaror);
            List<string> menu = new List<string> { "Gå tillbaka" };
            List<Page> menuTriggers = new List<Page> { Page.Merch };
            return PrintPage(menu, menuTriggers, "Vad vill du göra");
        }

        internal List<Vara> PrintAllItemsOfAType(int choosenType)
        {
            List<Vara> x = _dataAccess.GetAllVaraOfTyp(choosenType);
            PrintVara(x);
            return x;
        }

        internal void PrintAllItemsOfASubType(int choosenSubTyp, List<Vara> valdaVaror)
        {
            Console.Clear();
            List<Vara> subtypVara = new List<Vara>();
            foreach (Vara item in valdaVaror)
            {
                if (item.SubTypId == choosenSubTyp)
                {
                    subtypVara.Add(item);
                }
            }
            PrintVara(subtypVara);
        }



        private void PrintVara(List<Vara> typVara)
        {
            foreach (Vara item in typVara)
            {
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.WriteLine("Id".PadRight(10) + "Typ".PadRight(10) + "Subtyp".PadRight(10) + "Status");
                Console.WriteLine(item.Id.ToString().PadRight(10) + item.TypNamn.PadRight(10) + item.SubTypNamn.PadRight(10) + item.StatusId);
                Console.WriteLine();
                Console.WriteLine("Beskrivning");
                Console.WriteLine(item.Beskrivning);
                Console.WriteLine();
                Console.WriteLine("Pris".PadRight(8) + "Datum inköpt");
                Console.WriteLine(item.Pris.ToString().PadRight(8) + item.DatumInköpt);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        internal IEntity PrintAllStatus()
        {

            List<IEntity> x = _dataAccess.GetAllStatus();
            var p = TypeChooser(x);
            return p;
        }
    }
}