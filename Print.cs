using Inventory.Classer;
using System;
using System.Collections.Generic;

namespace Inventory
{
    internal class Print
    {
        internal string varifran = "ingen";
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

        internal int PrintTypes(Page _currentPage)
        {
            List<IEntity> types = _dataAccess.GetAllTyps();
            varifran = "ejsub";
            var p = TypeChooser(types, _currentPage,1);
            return p.Id;
        }

        internal int PrintSubTypes(int choosenType, Page _currentPage)
        {
            List<IEntity> subTypes = _dataAccess.GetAllSubTyps(choosenType);
            varifran = "sub";
            var p = TypeChooser(subTypes, _currentPage, choosenType);
            return p.Id;
        }

        private IEntity TypeChooser(List<IEntity> type, Page _currentPage, int choosenType)
        {
            var choose = "a";
            int x = 0;
            bool couldParse;
            IEntity returnType = null;
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < type.Count; i++)
                {
                    Console.WriteLine($"{i}. {type[i].Namn}");
                }
                Console.WriteLine();

                if (_currentPage == Page.NewMerch)
                {
                    Console.WriteLine("a) Välj typ");
                    Console.WriteLine("b) Lägg till ny typ");
                    choose = Console.ReadKey().KeyChar.ToString().ToLower();
                }

                if (choose == "a")
                {
                    do
                    {
                        Console.Clear();
                        for (int i = 0; i < type.Count; i++)
                        {
                            Console.WriteLine($"{i}. {type[i].Namn}");
                        }
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Välj vilken");
                        Console.WriteLine();
                        couldParse = int.TryParse(Console.ReadLine(), out x);
                    }
                    while (!couldParse);
                    return type[x];
                }
                else if (choose == "b")
                {
                    Console.WriteLine();
                    if (varifran == "ejsub")
                    {
                        Console.WriteLine("Skriv in namn på typen");
                        string typinput = Console.ReadLine();
                        int typidt = _dataAccess.AddNewTyp(typinput);
                        Console.WriteLine("Skriv namn på subtypen");
                        string subtypinput = Console.ReadLine();
                        Console.WriteLine();

                        int subtypidt = _dataAccess.AddNewSubTyp(typidt, subtypinput);
                        List<IEntity> types = _dataAccess.GetAllTyps();
                        foreach (var item in types)
                        {
                            if (item.Id == typidt)
                            {
                                returnType = item;
                            }
                        }
                        return returnType;
                    }
                    else if (varifran == "sub")
                    {
                        Console.WriteLine("Skriv namn på subtypen");
                        Console.WriteLine();
                        string subtypinput = Console.ReadLine();
                        Console.WriteLine();

                        int subtypeidt = _dataAccess.AddNewSubTyp(choosenType, subtypinput);
                        List<IEntity> subTypes = _dataAccess.GetAllSubTyps(choosenType);
                        foreach (var item in subTypes)
                        {
                            if (item.Id == subtypeidt)
                            {
                                returnType = item;
                            }
                        }
                        return returnType;
                    }
                    return returnType;
                }
                else
                {
                    continue;
                }
            }
        }

        internal Page PrintSubtypeItems(int choosenType, List<Vara> valdaVaror, Page _currentPage)
        {
            Console.Clear();
            int choosenSubType = PrintSubTypes(choosenType, _currentPage);
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

        internal IEntity PrintAllStatus(Page _currentPage)
        {
            List<IEntity> x = _dataAccess.GetAllStatus();
            var p = TypeChooser(x, _currentPage, 1);
            return p;
        }
    }
}