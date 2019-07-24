using System;
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

                    case Page.Merch:
                        Merch();
                        break;

                    case Page.CheckMerch:
                        CheckMerch();
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
            _print.PrintHeader(head);

            _currentPage = _print.PrintPage(menu, menuTriggers);
        }

        private void Merch()
        {
            while (_currentPage == Page.Merch)
            {
                Console.Clear();
                string head = "Varor";
                List<string> menu = new List<string> { "Lägg till vara", "Titta på varor", "Gå tillbaka" };
                List<Page> menuTriggers = new List<Page> { Page.AddMerch, Page.CheckMerch, Page.Main };

                _print.PrintHeader(head);

                _currentPage = _print.PrintPage(menu, menuTriggers);
                if (_currentPage == Page.CheckMerch)
                {
                    CheckMerch();
                }
            }
        }

        private void CheckMerch()
        {
            Console.Clear();
            int choosenType = _print.PrintTypes();
            List<Vara> valdaVaror = _print.PrintAllItemsOfAType(choosenType);

            List<string> menu = new List<string> { "Se subtyper", "Gå tillbaka" };
            List<Page> menuTriggers = new List<Page> { Page.CheckOnSubtypes, Page.Merch };
            _currentPage = _print.PrintPage(menu, menuTriggers);
            if (_currentPage == Page.CheckOnSubtypes)
            {
                _currentPage = _print.PrintSubtypeItems(choosenType, valdaVaror);
            }
            _currentPage = Page.Merch;
        }

        private void AddMerch()
        {
            while (_currentPage != Page.Merch)
            {
                Console.Clear();
                string head = "Lägg till vara";
                List<string> menu = new List<string> { "Lägg till ny vara", "Gå tillbaka" };
                List<Page> menuTriggers = new List<Page> { Page.NewMerch, Page.Merch };

                _print.PrintHeader(head);

                _currentPage = _print.PrintPage(menu, menuTriggers);
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
    }
}