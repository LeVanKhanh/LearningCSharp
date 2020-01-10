namespace Principes.Interface_Segregation.Correct
{
    public class Isp_Correct_Test: ITest
    {
        public void Test()
        {
            var station = new Repository<Station>();
            station.Delete(new Station());
            var stationOffice = new Repository<StationOffice>();
            stationOffice.Delete(new StationOffice());
        }
    }
}
