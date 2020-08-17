namespace ShooterBL.RCLiteBL
{
    public class RCLData
    {

        // Навеска дроби
        public double ShotCharge { get; }
        // Стоимость дроби
        public double ShotPrice { get; }
        // Вес пороха в банке
        public double PowderVolume { get; }
        // Стоимость банки пороха
        public double PowderPrice { get; }
        // Навеска пороха
        public double PowderCharge { get; }
        // Стоимость гильзы
        public double HullPrice { get; }
        // Стоимость пыж-контейнера
        public double WadPrice { get; }
        // Стоимость капсюля
        public double PrimerPrice { get; }

        //Собираем введенные данные
        public RCLData(double shotCharge,
                       double shotPrice,
                       double powderPrice,
                       double powderVolume,
                       double powderCharge,
                       double hullPrice,
                       double wadPrice,
                       double primerPrice)
        {
            ShotCharge = shotCharge;
            ShotPrice = shotPrice;
            PowderVolume = powderVolume;
            PowderPrice = powderPrice;
            PowderCharge = powderCharge;
            HullPrice = hullPrice;
            WadPrice = wadPrice;
            PrimerPrice = primerPrice;
        }
    }
}
