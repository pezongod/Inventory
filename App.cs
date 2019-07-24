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
            List<string> menu = new List<string> {"Lägg till ny vara", "Avsluta" };
            List<Page> menuTriggers = new List<Page> {Page.AddMerch, Page.Exit };
            List<MenuItems> mainPage = new List<MenuItems>();

            _print.PrintPage();
        }
    }
}