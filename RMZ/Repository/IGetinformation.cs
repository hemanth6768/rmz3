namespace RMZ.Repository
{
    public interface IGetinformation
    {
        public object getzone(string facility, string data, string id);

        public object getbuilding(string facility, string data);

        public object getfacility(string facility, string data);
    }
}
