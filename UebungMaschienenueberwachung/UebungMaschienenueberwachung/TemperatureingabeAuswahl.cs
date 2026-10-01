namespace UebungMaschienenueberwachung
{
    internal partial class Program
    {
        public class TemperatureingabeAuswahl
        {
            public void TemperaturEingabe(List<int> Temperaturen)
            {
                const int obergrenzeFürMöglicheTemperaturen = 120;
                const int untergrenzeFürMöglicheTemperaturen = 0;
                const int abHierKritischeTemperatur = 90;
                int Temperatur;
                bool IstEineGueltigeTemperatur;
                bool EingabeBeenden;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-- 1 - Temperatur erfassen --");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Temperatur eingeben (x zum Beenden):");
                Console.WriteLine();
                do
                {
                    string EingabeTemperatur = Console.ReadLine();
                    if (EingabeTemperatur == "x" || EingabeTemperatur == "X")
                    {
                        EingabeBeenden = true;
                    }
                    else
                    {
                        EingabeBeenden = false;

                        IstEineGueltigeTemperatur = int.TryParse(EingabeTemperatur, out Temperatur);



                        if (!IstEineGueltigeTemperatur)
                        {
                            Console.WriteLine("Das war keine Temperatur! Bitte erneut eingeben.");
                        }
                        else
                        {
                            if (Temperatur <= obergrenzeFürMöglicheTemperaturen && Temperatur >= untergrenzeFürMöglicheTemperaturen)
                            {
                                Temperaturen.Add(Temperatur);
                                if (Temperatur > abHierKritischeTemperatur)
                                {
                                    Console.WriteLine("KRITISCH! Maschine sofort prüfen!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Fehler: Temperatur außerhalb des zulässigen Bereichs.");
                            }
                        }
                    }

                } while (!EingabeBeenden);
                Console.WriteLine("------------------------------");
                Console.WriteLine();
            }
        }
    }
}
