namespace UebungMaschienenueberwachung
{
    internal partial class Program
    {
        public class TemperaturenspeichernAuswahl
        {
            public void TemperaturenSpeichern(List<int> temperaturen)
            {
                System.IO.File.WriteAllLines("Temperaturen.txt", temperaturen.Select(x => x.ToString()));
            }
        }
    }
}
