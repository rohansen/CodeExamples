namespace Microsoft_Text_Analytics_API
{
    public class ConsultantBooking
    {
        public int Id { get; set; }
        public Consultant Consultant { get; set; }
        public string Review { get; set; }
        public string ReviewLanguage { get; set; }
        public string ISO6391Name { get; set; }
        public double Sentiment { get; set; }
        public double ShortSentiment
        {
            get
            {
                string s = (Sentiment * 100).ToString();
                return double.Parse(s.Length > 5 ? s.Substring(0, 5) : s);
            }
        }

        public Booking Booking { get; set; }
        public override string ToString()
        {
            return Consultant.Name + " on " + Booking.StartTime.ToShortDateString() + "(" + ShortSentiment+ "%)";
        }


    }
}