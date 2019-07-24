﻿using System;
using System.Collections.Generic;

namespace Inventory
{
    internal class App
    {
        private Print _print = new Print();
        private Page _currentPage = Page.Main;
        private DataAccess _dataaccess = new DataAccess();

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
                    case Page.NewMerch:
                        break;
                    case Page.Merch:
                        Merch();
                        break;
                    case Page.CheckMerch:
                        CheckMerch();
                        break;
                    default:
                        break;
                }
            }
        }



        public void MainPage()
        {
            Console.Clear();
            string head = "Main Page";
            List<string> menu = new List<string> { "Varor", "Avsluta" };
            List<Page> menuTriggers = new List<Page> { Page.Merch, Page.Exit };
            List<MenuItems> mainPageMenu = new List<MenuItems>();

            for (int i = 0; i < menu.Count; i++)
            {
                MenuItems x = new MenuItems(menu[i], menuTriggers[i]);
                mainPageMenu.Add(x);
            }
            _print.PrintHeader(head);

            _currentPage = _print.PrintPage(mainPageMenu);
        }

        private void Merch()
        {
            Console.Clear();
            string head = "Main Page";
            List<string> menu = new List<string> { "Lägg till vara", "Titta på varor", "Gå tillbaka" };
            List<Page> menuTriggers = new List<Page> { Page.AddMerch, Page.CheckMerch, Page.Main };
            List<MenuItems> mainPageMenu = new List<MenuItems>();

            for (int i = 0; i < menu.Count; i++)
            {
                MenuItems x = new MenuItems(menu[i], menuTriggers[i]);
                mainPageMenu.Add(x);
            }
            _print.PrintHeader(head);

            _currentPage = _print.PrintPage(mainPageMenu);
        }

        private void AddMerch()
        {
            while (_currentPage != Page.Main)
            {
                Console.Clear();
                string head = "Lägg till vara";
                List<string> menu = new List<string> { "Lägg till ny vara", "Gå tillbaka" };
                List<Page> menuTriggers = new List<Page> { Page.NewMerch, Page.Main };
                List<MenuItems> AddMerchPageMenu = new List<MenuItems>();
                for (int i = 0; i < menu.Count; i++)
                {
                    MenuItems x = new MenuItems(menu[i], menuTriggers[i]);
                    AddMerchPageMenu.Add(x);
                }
                _print.PrintHeader(head);
                
                _currentPage = _print.PrintPage(AddMerchPageMenu);
                if (_currentPage == Page.NewMerch)
                {
                    NewMerch();
                }
            }
        }

        private void NewMerch()
        {
            Console.Clear();
            int choosenType = _print.PrintTypes();
            Console.Clear();
            int choosenSubType = _print.PrintSubTypes(choosenType);
            Console.WriteLine("Lägg till beskrivning");
            string descrip = Console.ReadLine();
            Vara y = new Vara(descrip, choosenSubType);
            _dataaccess.AddVara(y);
            Console.ReadLine();
        }

        private void CheckMerch()
        {
            Console.Clear();
            int choosenType = _print.PrintTypes();
            _print.PrintAllItemsOfAType(choosenType);
            

        }
    }
}