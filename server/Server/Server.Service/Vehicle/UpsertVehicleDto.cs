namespace Server.Service.Vehicle
{
    public class UpsertVehicleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Cost { get; set; }
    }
}
