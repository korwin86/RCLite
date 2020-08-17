namespace ShooterBL.RCLiteBL
{
    public class RCLController
    {
        public double Result { get; }

        //Считаем стоимость патрона
        public RCLController(RCLData data)
        {
            //Если в банке пороха 0, считаем без пороха
            if (data.PowderVolume == 0)
            {
                Result = (data.ShotPrice / 1000 * data.ShotCharge)
                         + data.HullPrice
                         + data.WadPrice
                         + data.PrimerPrice;
            }
            //Иначе считаем с порохом
            else
            {
                Result = (data.ShotPrice / 1000 * data.ShotCharge)
                         + (data.PowderPrice / data.PowderVolume * data.PowderCharge)
                         + data.HullPrice
                         + data.WadPrice
                         + data.PrimerPrice;
            }
        }
    }
}
