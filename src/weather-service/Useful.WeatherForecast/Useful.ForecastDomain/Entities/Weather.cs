namespace Useful.ForecastDomain.Entities
{
    internal record Weather
    {
        public float Temperature { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }
}
