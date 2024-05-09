namespace mercantil_api.Models.Mercantil
{
    public class Client_Identify
    {
        public string IPAddress { get; set; }
        public string Browser_Agent { get; set; }

        Mobile Mobile = new();
    }
    class Mobile
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public string OS_Version { get; set; }

        Location Location { get; set; } = new();
    }

    class Location
    {
        public float Lat { get; set; }

        public float Lng{ get; set; }
    }
}
