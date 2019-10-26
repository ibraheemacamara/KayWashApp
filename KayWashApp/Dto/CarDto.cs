namespace KayWashApp.Dto
{
    public class CarDto
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }

        public byte[] Image { get; set; }
    }
}