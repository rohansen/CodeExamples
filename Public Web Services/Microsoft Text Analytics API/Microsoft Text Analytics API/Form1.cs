using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Microsoft_Text_Analytics_API
{
    public partial class Form1 : Form
    {
        private string API_KEY = "8e49a8c3e07b44d78cf560a21631bd80";
        //https://westus.dev.cognitive.microsoft.com/docs/services/TextAnalytics.V2.0/operations/56f30ceeeda5650db055a3c7  <-- Detect languages
        public Form1()
        {
            InitializeComponent();
            GeneratePlaceholderBookings();
        }

        //Example - Not using this atm 
        private SentimentRequest DetectLanguage(Consultant c)
        {
            RestClient client = new RestClient("https://westeurope.api.cognitive.microsoft.com/text/analytics/v2.0/languages");
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", API_KEY); // GET KEY FROM AZURE PORTAL - FACE API
            request.AddHeader("Content-Type", "application/json");
            SentimentRequest rq = new SentimentRequest();
            rq.Documents = new List<Document>(c.ConsultantBookings.Count);
            foreach (var item in c.ConsultantBookings)
            {
                rq.Documents.Add(new Document { Id = item.Id.ToString(), Text = item.Review });
            }
            //This will automatically serialize the SentimentRequest as JSON
            request.AddJsonBody(rq);
            //Reusing the sentiment request type for the response
            IRestResponse<SentimentRequest> response = client.Execute<SentimentRequest>(request);
            return response.Data;
        }

        private SentimentRequest GetSentiments(Consultant c)
        {
            RestClient client = new RestClient("https://westeurope.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment");
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", API_KEY); // GET KEY FROM AZURE PORTAL - FACE API
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            SentimentRequest rq = new SentimentRequest();
            rq.Documents = new List<Document>(c.ConsultantBookings.Count);
            foreach (var item in c.ConsultantBookings)
            {
                rq.Documents.Add(new Document { Id = item.Id.ToString(), Language = item.ISO6391Name, Text = item.Review });
            }
            //This will automatically serialize the SentimentRequest as JSON
            request.AddJsonBody(rq);
            //Reusing the sentiment request type for the response
            IRestResponse<SentimentRequest> response = client.Execute<SentimentRequest>(request);
            return response.Data;
        }

        private Consultant GeneratePlaceholderBookings()
        {
            Consultant c1 = new Consultant { Name = "Jens Jensen" };
            Booking b1 = new Booking() { Agenda = "Some weird agenda", StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(1) };
            Booking b2 = new Booking() { Agenda = "Some other agenda", StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(1) };
            Booking b3 = new Booking() { Agenda = "Some fake agenda", StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(1) };
            Booking b4 = new Booking() { Agenda = "En dagsorden", StartTime = DateTime.Now, EndTime = DateTime.Now.AddDays(1) };
            ConsultantBooking cb1 = new ConsultantBooking { Id = 1, Review = "Wow, that was an awesome meeting!!", Booking = b1, Consultant = c1 };
            ConsultantBooking cb2 = new ConsultantBooking { Id = 2, Review = "Oh my god, this guy was horrible to talk to!", Booking = b2, Consultant = c1 };
            ConsultantBooking cb3 = new ConsultantBooking { Id = 3, Review = "When thinking about it, it was pretty standard service", Booking = b3, Consultant = c1 };
            ConsultantBooking cb4 = new ConsultantBooking { Id = 4, Review = "Hej med jer, jeg vil bare lige sige, at i gør et rigtigt godt stykke arbejde hos noname coorp.", Booking = b4, Consultant = c1 };
            c1.ConsultantBookings.Add(cb1);
            c1.ConsultantBookings.Add(cb2);
            c1.ConsultantBookings.Add(cb3);
            c1.ConsultantBookings.Add(cb4);
            b1.ConsultantBooking = cb1;
            b2.ConsultantBooking = cb2;
            b3.ConsultantBooking = cb3;
            b4.ConsultantBooking = cb4;
            lbBooking.Items.Clear();
            //Get language from ms
            var languages = DetectLanguage(c1);
            //Get sentiments from MS
            var sentiments = GetSentiments(c1);
            //Set the sentiment to the booking that it belongs to
            foreach (var item in c1.ConsultantBookings)
            {
                item.ReviewLanguage = languages.Documents.FirstOrDefault(x => x.Id == item.Id.ToString()).DetectedLanguages.FirstOrDefault().Name;
                item.ISO6391Name = languages.Documents.FirstOrDefault(x => x.Id == item.Id.ToString()).DetectedLanguages.FirstOrDefault().ISO6391Name;
                item.Sentiment = sentiments.Documents.FirstOrDefault(x => x.Id == item.Id.ToString()).Score;
                
            }
            //Fill listbox
            foreach (var item in c1.ConsultantBookings.OrderBy(x => x.Sentiment))
            {
                lbBooking.Items.Add(item);
            }

            return c1;

        }

        private void lbBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultantBooking cb = (ConsultantBooking)lbBooking.SelectedItem;
            label2.Text = cb.ShortSentiment + "% positive";
            textBox1.Text = cb.Review;
            textBox1.Text += Environment.NewLine  + "Language " + cb.ReviewLanguage;
        }
    }
}
