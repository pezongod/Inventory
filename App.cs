using System;
using System.Collections.Generic;

namespace Inventory
{
    internal class App
    {
        Print _print = new Print();
        Page _currentPage = Page.Main;
        DataAccess _dataaccess = new DataAccess();
        public void Run()
        {
            while (true)
            {

            switch (_currentPage)
            {
                case Page.Main:
                    MainPage();
                    break;
                case Page.AddMerch:
                    AddMerch();
                    break;
                case Page.Exit:
                    break;
                default:
                    break;
            }
            }

        }



        public void MainPage()
        {
            string head = "Main Page";
            List<string> menu = new List<string> {"Lägg till ny vara", "Avsluta" };
            List<Page> menuTriggers = new List<Page> {Page.AddMerch, Page.Exit };
            List<MenuItems> mainPageMenu = new List<MenuItems>();
            
            for (int i = 0; i < menu.Count; i++)
            {
                MenuItems x = new MenuItems(menu[i], menuTriggers[i]);
                mainPageMenu.Add(x);
            }

            _currentPage = _print.PrintPage(head, mainPageMenu);
        }

        private void AddMerch()
        {
            Console.Clear();
            Console.WriteLine("Lägg till beskrivning");
            string descrip = Console.ReadLine();
            Console.WriteLine("Lägg till typ id");
            int typid = int.Parse(Console.ReadLine());
            Vara x = new Vara(descrip, typid);
            _dataaccess.AddVara(x);
            _currentPage = Page.Main;
        }
    }
}