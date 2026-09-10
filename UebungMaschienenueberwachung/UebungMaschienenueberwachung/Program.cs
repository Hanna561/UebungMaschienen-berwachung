namespace UebungMaschienenueberwachung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Temperaturen = [];
            int Temperatur;
            bool IstEineTemperatur;
            bool TestObBeenden;

            Hauptmenü();

            string Auswahl = Console.ReadLine();
            if (Auswahl == "1")
            {
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

        }

        private static void Hauptmenü()
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
