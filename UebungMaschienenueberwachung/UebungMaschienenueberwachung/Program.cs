using System.ComponentModel.Design;

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
                programmBeenden = Programmauswahl(Temperaturen, Auswahl);

            } while (!programmBeenden);
        }

        private static bool Programmauswahl(List<int> Temperaturen, string Auswahl)
        {
            bool programmBeenden = false;
            int Summe = 0;
            int min = int.MaxValue;
            int max = int.MinValue;
            // Diese Variable benutzt du nur bei GrenzwertePruefen. 
            // Du könntest überlegen, ob du diese Variable direkt in der Methode GrenzwertePruefen deklarierst, da sie nur dort verwendet wird.
            // Oder noch einfacher in der Schleife selbst direkt den Temperaturen.Count zu verwenden.
            int anzahlElemente = Temperaturen.Count;
            if (Auswahl == "1")
            {
                TemperaturEingabe(Temperaturen);
            }
            else if (Auswahl == "2")
            {
                // Schau mal ob du die Werte wirklich per ref übergeben musst oder nicht doch direkt in der Methode deklariert werden können
                StatistikAnzeige(Temperaturen, ref Summe, ref min, ref max);
            }
            else if (Auswahl == "3")
            {
                GrenzwertePruefen(Temperaturen, anzahlElemente);
            }
            else if (Auswahl == "4")
            {
                int TemperaturSucheAusgabe;
                bool TemperaturSucheBeenden = false;
                Console.WriteLine("--- 4 - Temperatur suchen ---");
                Console.WriteLine();

                // Du könntest hier überlegen, ob du die Suche nach der Temperatur in einer eigenen Methode kapselst
                // Außerdem wäre zu überlegen, ob man die Suche nach der Temperatur effizienter gestalten kann, z.B. durch eine for Schleife über die gesamte Liste.
                // Man muss aktuell nach jedem Durchlauf auch wieder eine Temperatur eingeben oder 'x' zum Beenden.
                do
                {
                    int i = 0;
                    string TemperaturSucheEingabe = Console.ReadLine();
                    int.TryParse(TemperaturSucheEingabe, out TemperaturSucheAusgabe);
                    if (TemperaturSucheEingabe == "x")
                    {
                        TemperaturSucheBeenden = true;
                    }
                    else
                    {
                        int TemperaturAusListe = Temperaturen[i];
                        
                        if (TemperaturSucheAusgabe == TemperaturAusListe)
                        {
                            Console.WriteLine("Temperatur gefunden");
                        }
                        else
                        {

                            Console.WriteLine("Temperatur nicht gefunden");
                        }
                    }
                    i++;
                } while (!TemperaturSucheBeenden);

            }
            else if (Auswahl == "0")
            {
                programmBeenden = true;
            }


            return programmBeenden;

        }

        // GrenzwertePruefen hat aktuell 2 Aufgaben:
        // 1. Prüfen, ob die Temperaturen innerhalb der Grenzwerte liegen.
        // 2. Ausgabe der Kategorie der Temperatur (Kühl, Normal, Warnung)
        // Hinweis: Diese Methode verändert die Konsolenausgabe direkt und gibt keine Werte zurück.
        private static void GrenzwertePruefen(List<int> Temperaturen, int anzahlElemente)
        {
            Console.Clear();
            int WarnungZaeler = 0;
            for (int i = 0; i < anzahlElemente; i++)
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
                    WarnungZaeler++;
                }
            }
            Console.WriteLine("Anzahl Warnungen: " + WarnungZaeler);
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }


        // StatistikAnzeige hat aktuell 4 Aufgaben:
        // 1. Berechnung der Summe der Temperaturen.
        // 2. Bestimmung des Minimums.
        // 3. Bestimmung des Maximums.
        // 4. Berechnung und Ausgabe des Durchschnitts.
        // Hinweis: Diese Methode verändert die Konsolenausgabe direkt und gibt keine Werte zurück.
        private static void StatistikAnzeige(List<int> Temperaturen, ref int Summe, ref int min, ref int max)
        {
            double Durchschnitt;
            int AnzahlTemperaturenFuerSatistik = 0;
            int anzahlElemente = Temperaturen.Count;
            for (int i = 0; i < anzahlElemente; i++)
            {

                int TemperaturAusListe = Temperaturen[i];
                Summe += TemperaturAusListe;
                AnzahlTemperaturenFuerSatistik++;
                if (TemperaturAusListe < min)
                {
                    min = TemperaturAusListe;
                }
                if (TemperaturAusListe > max)
                {
                    max = TemperaturAusListe;
                }
            }
            Durchschnitt = Summe / AnzahlTemperaturenFuerSatistik;
            Console.Clear();
            Console.WriteLine("-- 2 - Statistik anzeigen --");
            Console.WriteLine();
            Console.WriteLine("Anzahl Messungen: " + AnzahlTemperaturenFuerSatistik);
            Console.WriteLine("Durchschnitt: " + Durchschnitt + " °C");
            Console.WriteLine("Minimum: " + min + " °C");
            Console.WriteLine("Maximum: " + max + " °C");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }

        private static void TemperaturEingabe(List<int> Temperaturen)
        {
            int Temperatur;
            // Der Name ist nicht optimal, besser wäre z.B. "IstEineGueltigeTemperatur".
            bool IstEineTemperatur;
            // Der Name ist nicht optimal, da er nicht eindeutig beschreibt, dass es sich um die Abbruchbedingung handelt.
            // Besser wäre z.B. "AbbruchbedingungErreicht" oder "EingabeBeenden".
            bool TestObBeenden;

            Console.Clear();
            Console.WriteLine("-- 1 - Temperatur erfassen --");
            Console.WriteLine();
            Console.WriteLine("Temperatur eingeben (x zum Beenden):");
            do
            {
                string EingabeTemperatur = Console.ReadLine();
                // Ein großes "X" würde aktuell nicht als Abbruch erkannt werden.
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
                        // Solche direkte nutzung von Zahlenwerten ist nicht optimal. Besser wäre es, Konstanten zu verwenden.
                        // Die kann man dann an einer zentralen Stelle ändern, falls sich die Grenzwerte ändern sollten.
                        if (Temperatur <= 120 && Temperatur >= 0)
                        {
                            Temperaturen.Add(Temperatur);
                            if (Temperatur > 90)
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

            } while (!TestObBeenden);
            Console.WriteLine("------------------------------");
            Console.WriteLine();
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
            Console.WriteLine("4 - Temperatur suchen");
            Console.WriteLine("0 - Program beenden");
            Console.WriteLine();
            Console.Write("Auswahl:  ");
        }
    }
}
