namespace UebungMaschienenueberwachung
{
    internal partial class Program
    {
        // GrenzwertePruefen hat aktuell 2 Aufgaben:
        // 1. Prüfen, ob die Temperaturen innerhalb der Grenzwerte liegen.
        // 2. Ausgabe der Kategorie der Temperatur (Kühl, Normal, Warnung)
        // Hinweis: Diese Methode verändert die Konsolenausgabe direkt und gibt keine Werte zurück.
        public class GrenzwerteprüfenAuswahl
        {
            public void GrenzwertePrüfen(List<int> Temperaturen)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-- 3 - Grenzwerte prüfen --");
                Console.ResetColor();
                Console.WriteLine();
                int WarnungZähler = 0;

                for (int i = 0; i < Temperaturen.Count; i++)
                {
                    int TemperaturAusListe = Temperaturen[i];
                    if (TemperaturAusListe < 50)
                    {
                        Console.WriteLine(TemperaturAusListe + " °C -> Kühl");
                    }
                    else if (TemperaturAusListe >= 50 && TemperaturAusListe <= 80)
                    {
                        Console.WriteLine(TemperaturAusListe + " °C -> Normal");
                    }
                    else
                    {
                        Console.WriteLine(TemperaturAusListe + " °C -> Warnung");
                        WarnungZähler++;
                    }
                }
                Console.WriteLine("Anzahl Warnungen: " + WarnungZähler);
                Console.WriteLine("------------------------------");
                Console.WriteLine();
            }
        }
    }
}
