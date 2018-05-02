using Emgu.CV;
using Emgu.CV.Structure;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerVisionLogin
{
    public partial class Form1 : Form
    {
        private RestClient client;
        private Mat lastFrame = null;
        private VideoCapture cap = new VideoCapture();
        private string API_KEY = "XXXXXXXXX";
        public Form1()
        {
            InitializeComponent();
            cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps, 30.0);
            cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameHeight, 240);
            cap.SetCaptureProperty(Emgu.CV.CvEnum.CapProp.FrameWidth, 320);
            Application.Idle += Application_Idle; // When application is idle, keep streaming data to the picturebox
            client = new RestClient("https://westeurope.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceAttributes=age,gender,smile,facialHair,glasses,emotion,hair,makeup");

        }

        private void Application_Idle(object sender, EventArgs e)
        {
            StreamVideo();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var imageBytes = ImageToByteArray(lastFrame.Bitmap);

            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Ocp-Apim-Subscription-Key", API_KEY); // GET KEY FROM AZURE PORTAL - FACE API
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddParameter("application/octet-stream", imageBytes, ParameterType.RequestBody);
            IRestResponse<List<FaceRecognitionRequest>> response = client.Execute<List<FaceRecognitionRequest>>(request);
            var firstResponse = response.Data.FirstOrDefault();
            PrintImageData(firstResponse);
            if (firstResponse.faceAttributes.emotion.happiness > 0.8)
            {
                MessageBox.Show("You are logged in!!! HAPPYDAYS!, you look like a " + firstResponse.faceAttributes.age + " year old " + firstResponse.faceAttributes.gender);
            }
            else
            {
                MessageBox.Show("You need to be happier to log in");
            }


        }

        private void PrintImageData(FaceRecognitionRequest firstResponse)
        {
            textBox1.Clear();
            textBox1.AppendText(nameof(firstResponse.faceAttributes.hair.bald) + firstResponse.faceAttributes.hair.bald + Environment.NewLine);

            foreach (var item in firstResponse.faceAttributes.hair.hairColor)
            {
                textBox1.AppendText(nameof(item.color) + " " + item.color + nameof(item.confidence) + " " + item.confidence + Environment.NewLine);
            }
            textBox1.AppendText(nameof(firstResponse.faceAttributes.gender) + firstResponse.faceAttributes.gender + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.glasses) + firstResponse.faceAttributes.glasses + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.smile) + firstResponse.faceAttributes.smile + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.makeup.eyeMakeup) + firstResponse.faceAttributes.makeup.eyeMakeup + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.makeup.lipMakeup) + firstResponse.faceAttributes.makeup.lipMakeup + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.emotion.anger) + firstResponse.faceAttributes.emotion.anger + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.emotion.contempt) + firstResponse.faceAttributes.emotion.contempt + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.emotion.disgust) + firstResponse.faceAttributes.emotion.disgust + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.emotion.fear) + firstResponse.faceAttributes.emotion.fear + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.emotion.happiness) + firstResponse.faceAttributes.emotion.happiness + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.emotion.neutral) + firstResponse.faceAttributes.emotion.neutral + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.emotion.sadness) + firstResponse.faceAttributes.emotion.sadness + Environment.NewLine);
            textBox1.AppendText(nameof(firstResponse.faceAttributes.emotion.surprise) + firstResponse.faceAttributes.emotion.surprise + Environment.NewLine);

        }

        private void StreamVideo()
        {
            lastFrame = cap.QueryFrame();
            pictureBox1.Image = lastFrame.Bitmap;
        }
        public static byte[] ImageToByteArray(System.Drawing.Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
