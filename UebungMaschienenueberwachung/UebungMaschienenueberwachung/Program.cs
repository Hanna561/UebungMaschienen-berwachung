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
            int anzahlElemente = Temperaturen.Count;
            if (Auswahl == "1")
            {
                TemperaturEingabe(Temperaturen);
            }
            else if (Auswahl == "2")
            {
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
