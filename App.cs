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

            _currentPage = _print.PrintPage(menu, menuTriggers, "Vad vill du göra?");
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

                _currentPage = _print.PrintPage(menu, menuTriggers, "Vad vill du göra?");
                if (_currentPage == Page.CheckMerch)
                {
                    CheckMerch();
                }
            }
        }

        private void CheckMerch()
        {
            Console.Clear();
            int choosenType = _print.PrintTypes(_currentPage);
            List<Vara> valdaVaror = _print.PrintAllItemsOfAType(choosenType);

            List<string> menu = new List<string> { "Se subtyper", "Gå tillbaka" };
            List<Page> menuTriggers = new List<Page> { Page.CheckOnSubtypes, Page.Merch };
            _currentPage = _print.PrintPage(menu, menuTriggers, "Vad vill du göra?");
            if (_currentPage == Page.CheckOnSubtypes)
            {
                _currentPage = _print.PrintSubtypeItems(choosenType, valdaVaror, _currentPage);
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

                _currentPage = _print.PrintPage(menu, menuTriggers, "Vad vill du göra?");
                if (_currentPage == Page.NewMerch)
                {
                    NewMerch();
                }
            }
        }

        private void NewMerch()
        {
            Console.Clear();
            int choosenType = _print.PrintTypes(_currentPage);
            Console.Clear();
            int choosenSubType = _print.PrintSubTypes(choosenType, _currentPage);
            Vara varaAttLäggaTill = new Vara();
            varaAttLäggaTill.TypId = choosenType;
            varaAttLäggaTill.SubTypId =choosenSubType;

            while (_currentPage!=Page.AddMerch)
            {
                Console.Clear();
            List<string> menu = new List<string> {
            "Beskrivning",
            "Status",
            "Pris",
            "Datum inköpt",
            "Spara",
            "Gå tillbaka"};
            List<Page> menuTriggers = new List<Page> { Page.AddDescrip, Page.AddStatus, Page.AddPrice, Page.AddDate,Page.Save, Page.AddMerch };
            _currentPage = _print.PrintPage(menu, menuTriggers, "Vad vill lägga till?");
            switch (_currentPage)
            {
                case Page.AddMerch:
                    break;
                case Page.AddDescrip:

                    Console.WriteLine("Ange beskrivning:");
                        string temp = Console.ReadLine();
                        varaAttLäggaTill.Beskrivning = temp;
                    break;
                case Page.AddStatus:
                        Console.WriteLine("Ange Status:");
                        var p = _print.PrintAllStatus(_currentPage);
                        varaAttLäggaTill.StatusId = p.Id;
                        varaAttLäggaTill.StatusNamn = p.Namn;
                        
                        break;
                case Page.AddPrice:
                    break;
                case Page.AddDate:
                    break;
                case Page.Save:
                    _dataaccess.AddVara(varaAttLäggaTill);
                        _currentPage = Page.AddMerch;
                        Console.WriteLine("Varan blev tillagd");
                        Console.ReadKey();
                    break;
                default:
                    break;
                }
            }

        }
    }
}