using System;
using System.Collections.Generic;

namespace Inventory
{
    internal class App
    {
        Print _print = new Print();
        public void Run()
        {
            throw new NotImplementedException();
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

            _print.PrintPage(head, mainPageMenu);
        }
    }
}