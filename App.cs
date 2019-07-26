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
            bool exit = false;
            while (!exit)
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
                    case Page.Exit:
                        exit = true;
                        break;
                }
            }
        }

        public void MainPage()
        {
            Console.Clear();
            //string head = "Main Page";
            WriteMain();
            List<string> menu = new List<string> { "Varor", "Avsluta" };
            List<Page> menuTriggers = new List<Page> { Page.Merch, Page.Exit };
            //_print.PrintHeader(head);

            _currentPage = _print.PrintPage(menu, menuTriggers, "Vad vill du göra?");
        }

        private void WriteMain()
        {
            Console.WriteLine("XX");
            Console.WriteLine("XXXX        XXXX");
            Console.WriteLine("XXXXX     XXXXXX");
            Console.WriteLine("XXX XX   XXX XXX        XXX        XX  X        XX");
            Console.WriteLine("XX   XX XX   XXX      XXX XXXX     XX  XXX      XX");
            Console.WriteLine("XX    XXX    XXX     XX     XXX    XX  XXXX     XX");
            Console.WriteLine("XX     X     XXX    XX        X    XX  XX XX    XX");
            Console.WriteLine("XXX          XXX    XXXXXXXXXXXX   XX  XX  XX   XX");
            Console.WriteLine("XXX          XXX    XXX      XXX   XX  XX   XX  XXX");
            Console.WriteLine("XXX          XXX    XXX      XXX   XX  XX    XX XXX");
            Console.WriteLine("XX           XXX    XXX       XX   XX  XX     XXXXX");
            Console.WriteLine("                              XX   XX  XX      XXX");
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

                DrawHeart();


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

        private void DrawHeart()
        {
Console.WriteLine("  XXXXXX             ");
Console.WriteLine("XXXXXXXXXX    XXXXX  ");
Console.WriteLine("XXXXXXXXXX XXXXXXXXXX");
Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
Console.WriteLine("  XXXXXXXXXXXXXXXXXX ");
Console.WriteLine("   XXXXXXXXXXXXXXX   ");
Console.WriteLine("     XXXXXXXXXXXX    ");
Console.WriteLine("       XXXXXXXX      ");
Console.WriteLine("        XXXXX        ");
            Console.WriteLine("          XX         ");
        }

        private void NewMerch()
        {
            Console.Clear();
            int choosenType = _print.PrintTypes(_currentPage);
            Console.Clear();
            int choosenSubType = _print.PrintSubTypes(choosenType, _currentPage);
            Vara varaAttLäggaTill = new Vara();
            varaAttLäggaTill.TypId = choosenType;
            varaAttLäggaTill.SubTypId = choosenSubType;

            while (_currentPage != Page.AddMerch)
            {
                Console.Clear();
                _print.PrintHeader("Lägger till ny vara....");
                List<string> menu = new List<string> {
            "Beskrivning",
            "Status",
            "Pris",
            "Datum inköpt",
            "Spara",
            "Gå tillbaka"};
                List<Page> menuTriggers = new List<Page> { Page.AddDescrip, Page.AddStatus, Page.AddPrice, Page.AddDate, Page.Save, Page.AddMerch };
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
                        int pris;
                        bool canparse;
                        do
                        {
                            Console.WriteLine("Skriv in priset");
                            canparse = int.TryParse(Console.ReadLine(), out pris);
                            if (!canparse)
                            {
                                Console.WriteLine("Skriv en siffra");
                            }
                        } while (!canparse);
                        varaAttLäggaTill.Pris = pris;
                        break;

                    case Page.AddDate:
                        bool parsedatetry = false; ;
                        DateTime datum = new DateTime();
                        while (!parsedatetry)
                        {
                            Console.Clear();

                            Console.WriteLine("Skirv in datum i formatet (år-månad-dag) xxxx-xx-xx");
                           
                            parsedatetry = DateTime.TryParse(Console.ReadLine(), out datum);
                        }
                        varaAttLäggaTill.DatumInköpt = datum;
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
        public static void PaintVaror()
        {

            System.Console.WriteLine(@"X              X        XX                                             XXXX      ");
            System.Console.WriteLine(@"XX             X        X XX          XXXXX           XXXXXXX         X    XX    ");
            System.Console.WriteLine(@" XX            X       X    X         XX  X         XX X     XX       X      X   ");
            System.Console.WriteLine(@"  XXX         X       XX     X        X   X         XXX        XX     X     X    ");
            System.Console.WriteLine(@"    XX        X      XXXXX XXX        X   X         XX          X     X XXXX     ");
            System.Console.WriteLine(@"     XX      X       X        X       X XX         XX           X     XXX        ");
            System.Console.WriteLine(@"      XX            XX        X       XXXX         X            X     X XXX      ");
            System.Console.WriteLine(@"       XX X         X         X       X    XXX     XX         XX      X   XX     ");
            System.Console.WriteLine(@"         XX        XX         X       X      XX     XXX     XXX       X     XX   ");
            System.Console.WriteLine(@"                                      X       X        XXXXXX         X      XXX ");

        }
    }
}