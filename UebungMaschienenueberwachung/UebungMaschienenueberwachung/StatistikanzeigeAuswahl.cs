namespace UebungMaschienenueberwachung
{
    internal partial class Program
    {
        // StatistikAnzeige hat aktuell 4 Aufgaben:
        // 1. Berechnung der Summe der Temperaturen.
        // 2. Bestimmung des Minimums.
        // 3. Bestimmung des Maximums.
        // 4. Berechnung und Ausgabe des Durchschnitts.
        // Hinweis: Diese Methode verändert die Konsolenausgabe direkt und gibt keine Werte zurück.
        public class StatistikanzeigeAuswahl
        {
            public void StatistikAnzeige(List<int> Temperaturen)
            {
                int Summe = 0;
                int min = int.MaxValue;
                int max = int.MinValue;
                double Durchschnitt;
                int AnzahlTemperaturenFürSatistik = 0;
                int anzahlElemente = Temperaturen.Count;
                for (int i = 0; i < anzahlElemente; i++)
                {

                    int TemperaturAusListe = Temperaturen[i];
                    Summe += TemperaturAusListe;
                    AnzahlTemperaturenFürSatistik++;
                    if (TemperaturAusListe < min)
                    {
                        min = TemperaturAusListe;
                    }
                    if (TemperaturAusListe > max)
                    {
                        max = TemperaturAusListe;
                    }
                }
                Durchschnitt = Summe / AnzahlTemperaturenFürSatistik;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-- 2 - Statistik anzeigen --");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Anzahl Messungen: " + AnzahlTemperaturenFürSatistik);
                Console.WriteLine("Durchschnitt: " + Durchschnitt + " °C");
                Console.WriteLine("Minimum: " + min + " °C");
                Console.WriteLine("Maximum: " + max + " °C");
                Console.WriteLine("------------------------------");
                Console.WriteLine();
            }
        }
    }
}
