using System.ComponentModel.Design;

namespace UebungMaschienenueberwachung
{
    internal class Program
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
            
            
            
            if (Auswahl == (int)AuswahlProgarmm.TemperaturEingabeAuswahl1)
            {
                TemperaturEingabe(Temperaturen);
            }
            else if (Auswahl == (int)AuswahlProgarmm.StatistikAnzeigeAuswahl2)
            {
                StatistikAnzeige(Temperaturen);
            }
            else if (Auswahl == (int)AuswahlProgarmm.GrenzwertePruefenAuswahl3)
            {
                GrenzwertePruefen(Temperaturen);
            }
            else if (Auswahl == (int)AuswahlProgarmm.TemperaturenSuchenAuswahl4)
            {
                TemperaturenSuchen(Temperaturen);
            }
            else if (Auswahl == (int)AuswahlProgarmm.TemperaturenSpeichernAuswahl5)
            {
                TemperaturenSpeichern(Temperaturen);
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

        private static void TemperaturenSpeichern(List<int> temperaturen)
        {
            System.IO.File.WriteAllLines("Temperaturen.txt", temperaturen.Select(x => x.ToString()));
        }

        private static void TemperaturenSuchen(List<int> Temperaturen)
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

        // GrenzwertePruefen hat aktuell 2 Aufgaben:
        // 1. Prüfen, ob die Temperaturen innerhalb der Grenzwerte liegen.
        // 2. Ausgabe der Kategorie der Temperatur (Kühl, Normal, Warnung)
        // Hinweis: Diese Methode verändert die Konsolenausgabe direkt und gibt keine Werte zurück.
        private static void GrenzwertePruefen(List<int> Temperaturen)
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


        // StatistikAnzeige hat aktuell 4 Aufgaben:
        // 1. Berechnung der Summe der Temperaturen.
        // 2. Bestimmung des Minimums.
        // 3. Bestimmung des Maximums.
        // 4. Berechnung und Ausgabe des Durchschnitts.
        // Hinweis: Diese Methode verändert die Konsolenausgabe direkt und gibt keine Werte zurück.
        private static void StatistikAnzeige(List<int> Temperaturen)
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

        private static void TemperaturEingabe(List<int> Temperaturen)
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
