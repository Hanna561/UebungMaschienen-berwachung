using System.ComponentModel.Design;
using static UebungMaschienenueberwachung.Program.TemperaturenspeichernAuswahl;

namespace UebungMaschienenueberwachung
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            List<int> Temperaturen = [];

            if (System.IO.File.Exists("Temperaturen.txt"))
            {
                var dateiInhalt = System.IO.File.ReadAllLines("Temperaturen.txt");
                foreach (var line in dateiInhalt)
                {
                    Temperaturen.Add(int.Parse(line));
                }
            }

            bool programmBeenden;
            do
            {
                AnzeigeHauptmenü();
                int AuswahlAusDemHauptmenü = int.Parse(AuswahlImAnzeigeHauptmenü());
                programmBeenden = Programmauswahl(Temperaturen, AuswahlAusDemHauptmenü);

            } while (!programmBeenden);
        }
        public enum AuswahlProgarmm
        {
            TemperaturEingabeAuswahl1 = 1,
            StatistikAnzeigeAuswahl2 = 2,
            GrenzwertePruefenAuswahl3 = 3,
            TemperaturenSuchenAuswahl4 = 4,
            TemperaturenSpeichernAuswahl5 = 5,
            programmBeendenAuswahl = 0
        }

        private static bool Programmauswahl(List<int> Temperaturen, int Auswahl)
        {
            bool programmBeenden = false;

            TemperatureingabeAuswahl TemperaturEingabe = new();
            StatistikanzeigeAuswahl StatistikAnzeige = new();
            GrenzwerteprüfenAuswahl GrenzwertePrüfen = new();
            TemperaturensucheAuswahl TemperaturenSuche = new();
            TemperaturenspeichernAuswahl TemperaturenSpeichern = new();


            if (Auswahl == (int)AuswahlProgarmm.TemperaturEingabeAuswahl1)
            {
                TemperaturEingabe.TemperaturEingabe(Temperaturen);
            }
            else if (Auswahl == (int)AuswahlProgarmm.StatistikAnzeigeAuswahl2)
            {
                StatistikAnzeige.StatistikAnzeige(Temperaturen);
            }
            else if (Auswahl == (int)AuswahlProgarmm.GrenzwertePruefenAuswahl3)
            {
                GrenzwertePrüfen.GrenzwertePrüfen(Temperaturen);
            }
            else if (Auswahl == (int)AuswahlProgarmm.TemperaturenSuchenAuswahl4)
            {
                TemperaturenSuche.TemperaturenSuchen(Temperaturen);
            }
            else if (Auswahl == (int)AuswahlProgarmm.TemperaturenSpeichernAuswahl5)
            {
                TemperaturenSpeichern.TemperaturenSpeichern(Temperaturen);
            }
            else if (Auswahl == (int)AuswahlProgarmm.programmBeendenAuswahl)
            {
                programmBeenden = true;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Diesen Menüpunkt gibt es nicht! Bitte erneut eingeben.");
                Console.WriteLine();
            }


            return programmBeenden;

        }

        private static string AuswahlImAnzeigeHauptmenü()
        {
            return Console.ReadLine();
        }

        private static void AnzeigeHauptmenü()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=== Maschienenüberwachung ===");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1 - Temperatur erfassen");
            Console.WriteLine("2 - Statistik anzeigen");
            Console.WriteLine("3 - Grenzwerte prüfen");
            Console.WriteLine("4 - Temperatur suchen");
            Console.WriteLine("5 - Temperaturen Speichern");
            Console.WriteLine("0 - Program beenden");
            Console.WriteLine();
            Console.Write("Auswahl:  ");
        }
    }
}
