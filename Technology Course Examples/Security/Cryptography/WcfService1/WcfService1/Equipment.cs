namespace WcfService1
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Booking Booking { get; set; }
        public double Price { get; set; }
    }
}