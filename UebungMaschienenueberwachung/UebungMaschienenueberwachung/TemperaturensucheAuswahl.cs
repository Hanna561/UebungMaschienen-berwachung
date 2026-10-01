namespace UebungMaschienenueberwachung
{
    internal partial class Program
    {
        public class TemperaturensucheAuswahl
        {
            public void TemperaturenSuchen(List<int> Temperaturen)
            {
                int TemperaturSucheAusgabe;
                bool TemperaturSucheBeenden = false;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- 4 - Temperatur suchen ---");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Temperatur eingeben (x zum Beenden):");
                Console.WriteLine();

                // Man muss aktuell nach jedem Durchlauf auch wieder eine Temperatur eingeben oder 'x' zum Beenden.
                do
                {

                    string TemperaturSucheEingabe = Console.ReadLine();
                    int.TryParse(TemperaturSucheEingabe, out TemperaturSucheAusgabe);
                    if (TemperaturSucheEingabe == "x" || TemperaturSucheEingabe == "X")
                    {
                        TemperaturSucheBeenden = true;
                    }
                    else
                    {
                        var TemperaturAusListe = Temperaturen.Where(temp => temp == TemperaturSucheAusgabe).ToList();
                        Console.WriteLine($"Deine Temperatur ist so oft vorhanden: {TemperaturAusListe.Count}");
                    }

                } while (!TemperaturSucheBeenden);
            }
        }
    }
}
