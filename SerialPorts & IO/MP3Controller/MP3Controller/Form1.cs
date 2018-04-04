using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3Controller
{
    public partial class Form1 : Form
    {
        private SerialPort port = new SerialPort("COM4", 115200);
        WaveOutEvent outputDevice = new WaveOutEvent();
        AudioFileReader audioFile = new AudioFileReader("ukulele.mp3");
        public Form1()
        {
            InitializeComponent();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            port.DataReceived += Port_DataReceived;

            port.Open();
            //Empty buffer
            port.ReadExisting();

            outputDevice.Init(audioFile);
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            float floatdata = float.Parse(port.ReadLine().Replace("A0:", ""));
            int actualData = int.Parse(port.ReadLine().Replace("A0:", ""));


            textBox1.Invoke(new Action(() =>
            {
                if (actualData != trackBar1.Value)
                {
                    textBox1.AppendText(floatdata / 1000 + Environment.NewLine);
                }
            }));
            textBox1.Invoke(new Action(() =>
            {
                if (actualData != trackBar1.Value)
                {
                    trackBar1.Value = actualData;
                }
            }));

            audioFile.Volume = floatdata / 1000;
        }

        private void ChangedTrackBar(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            PlayAndShowTimer();


            //new Action(() => { label1.Text = audioFile.TotalTime.Seconds + "/" + audioFile.CurrentTime.Seconds; }
        }

        private void PlayAndShowTimer()
        {
            float oldVolume = outputDevice.Volume;
            outputDevice.Volume = 0;
            outputDevice.Play();
            outputDevice.Volume = oldVolume;
            System.Threading.Timer timer = new System.Threading.Timer(UpdatePlayStatus, null, 0, 1000);
        }

        private void UpdatePlayStatus(object state)
        {
            label1.Invoke(new Action(() =>
            {
                if (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    string formatted = audioFile.CurrentTime.ToString(@"hh\:mm\:ss") + "/" + audioFile.TotalTime.ToString(@"hh\:mm\:ss");
                    label1.Text = formatted;
                }
                //  label1.Text = "Outside while";
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            outputDevice.Pause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            outputDevice.Stop();
            audioFile.Position = 0;
            label1.Text = "stopped...";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                audioFile = new AudioFileReader(openFileDialog1.FileName);
                if (outputDevice.PlaybackState == PlaybackState.Playing)
                    outputDevice.Stop();
                outputDevice.Init(audioFile);
                PlayAndShowTimer();

                label3.Text = "Now Playing: " + Path.GetFileName(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Cancelled");
            }
        }
    }
}
