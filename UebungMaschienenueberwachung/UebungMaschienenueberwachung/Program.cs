namespace UebungMaschienenueberwachung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Temperaturen = [];
            bool programmBeenden;
            do
            {
                AnzeigeHauptmenü();
                string Auswahl = AuswahlImAnzeigeHauptmenü();
                programmBeenden= Programmauswahl(Temperaturen, Auswahl);

            } while (!programmBeenden);
        }

        private static bool Programmauswahl(List<int> Temperaturen, string Auswahl)
        {
            bool programmBeenden = false;
            if (Auswahl == "1")
            {
                TemperaturEingabe(Temperaturen);
            }else if (Auswahl == "2")
            {

            }else if (Auswahl == "0")
            {
                programmBeenden = true;
            }


            return programmBeenden;

        }

        private static void TemperaturEingabe(List<int> Temperaturen)
        {
            int Temperatur;
            bool IstEineTemperatur;
            bool TestObBeenden;

            Console.Clear();
            Console.WriteLine("-- 1 - Temperatur erfassen --");
            Console.WriteLine();
            Console.WriteLine("Temperatur eingeben (x zum Beenden):");
            do
            {
                string EingabeTemperatur = Console.ReadLine();

                if (EingabeTemperatur == "x")
                {
                    TestObBeenden = true;
                }
                else
                {
                    TestObBeenden = false;

                    IstEineTemperatur = int.TryParse(EingabeTemperatur, out Temperatur);



                    if (!IstEineTemperatur)
                    {
                        Console.WriteLine("Das war keine Temperatur! Bitte erneut eingeben.");
                    }
                    else
                    {
                        Temperaturen.Add(Temperatur);
                    }
                }

            } while (!TestObBeenden);
        }

        private static string AuswahlImAnzeigeHauptmenü()
        {
            return Console.ReadLine();
        }

        private static void AnzeigeHauptmenü()
        {
            Console.WriteLine("=== Maschienenüberwachung ===");
            Console.WriteLine();
            Console.WriteLine("1 - Temperatur erfassen");
            Console.WriteLine("2 - Statistik anzeigen");
            Console.WriteLine("3 - Grenzwerte prüfen");
            Console.WriteLine("0 - Program beenden");
            Console.WriteLine();
            Console.Write("Auswahl:  ");
        }
    }
}
