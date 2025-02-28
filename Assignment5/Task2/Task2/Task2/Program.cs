namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleInsurance twoWheeler = new TwoWheelerInsurance();
            VehicleInsurance fourWheeler = new FourWheelerInsurance();
            VehicleInsurance commercial = new CommercialInsurance();

            twoWheeler.DisplayPremium();
            fourWheeler.DisplayPremium();
            commercial.DisplayPremium();
        }
    }
}
