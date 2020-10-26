namespace Principes.Interface_Segregation.Correct
{
    public class Isp_Correct_Test: ITest
    {
        public void Test()
        {
            var station = new StationRepository();
            station.Delete(new Station());
            var stationOffice = new StationOfficeRepository();
            stationOffice.Delete(new StationOffice());
        }
    }
}
