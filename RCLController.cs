namespace ShooterBL.RCLiteBL
{
    public class RCLController
    {
        public double Result { get; }
        public RCLController(RCLData data)
        {
            if (data.PowderVolume == 0)
            {
                Result = 0;
            }
            else
            {
                Result = (data.ShotPrice / 1000 * data.ShotCharge)
                         + (data.PowderPrice / data.PowderVolume * data.PowderCharge)
                         + data.HullPrice + data.WadPrice + data.PrimerPrice;
            }
        }
    }
}
