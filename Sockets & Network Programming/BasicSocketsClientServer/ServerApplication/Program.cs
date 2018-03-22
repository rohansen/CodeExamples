using ServerApplication.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using ServerApplication.Models.MapsAPI;
namespace ServerApplication
{
    class Program
    {
        private const int SERVER_PORT = 8888;
        private static IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, SERVER_PORT);
        private static TcpListener server = new TcpListener(endpoint);
        private static ConcurrentDictionary<int,MyTcpClient> clients;
        private static object ClientAmountLock = new object();
        private static int ClientAmount = 1;

        static void Main(string[] args)
        {
            clients = new ConcurrentDictionary<int, MyTcpClient>();
            //StartAcceptingClient(server);
            //Client Listener
            Thread clientListener = new Thread(() => StartAcceptingClient(server));
            clientListener.Start();

            Console.WriteLine("Server started...");
            Console.WriteLine("Type something..");
            do
            {

                string inputString = Console.ReadLine();

                foreach (var client in clients.Values)
                {
                    SendMessage(inputString, client);
                }

                

            } while (true);
        }



        public static void SendMessage(string message, MyTcpClient currentClient)
        {
            NetworkStream nws = currentClient.TcpClient.GetStream();
            byte[] msg = Encoding.UTF8.GetBytes(message);
            nws.Write(msg, 0, msg.Length);

        }
        public static void StartAcceptingClient(TcpListener srv)
        {
            while (true)
            {
                srv.Start();
                var currentClient = new MyTcpClient();
                currentClient.TcpClient = srv.AcceptTcpClient();//Blocking call
                lock (ClientAmountLock)
                {
                    currentClient.ClientId = ClientAmount;
                    clients.TryAdd(ClientAmount, currentClient);
                    ClientAmount++;
                }
                 
                Thread t = new Thread(() => HandleConnection(currentClient)); //constantly read the stream; blocking so in a thread
                t.Start();
            }
        }
        private static void HandleConnection(MyTcpClient currentClient)
        {

            while (currentClient.TcpClient.Connected)
            {
                try
                {
                    NetworkStream nws = currentClient.TcpClient.GetStream();
                    byte[] readBuffer = new byte[currentClient.TcpClient.ReceiveBufferSize];
                    int streamSize = -1;
                    while ((streamSize = nws.Read(readBuffer, 0, readBuffer.Length)) != 0)
                    {
                        string recievedData = Encoding.UTF8.GetString(readBuffer, 0, streamSize);
                        Console.WriteLine("Message Recieved: " + recievedData);
                        string commandValue = ParseCommand(recievedData, currentClient);

                        //send only back to the guy you recieved data from
                        //SendMessage(commandValue, currentClient);

                        //If you want to send out the recieved message to all connected clients, 
                        //Loop over the "clients" collection and do a SendMessage(msg, client)
                        foreach (var client in clients.Values.Where(x=>x!=currentClient))
                        {
                            SendMessage(recievedData, client);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MyTcpClient exit;
                    clients.TryRemove(currentClient.ClientId,out exit);
                    exit.TcpClient.Close();
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static string ParseCommand(string cmd, MyTcpClient currentClient)
        {
            //command pattern: command0 = what to do --> command1: arguments for first command
            string[] commands = cmd.Split(' ');

            if (commands.Length >= 2)
            {
                switch (commands[0])
                {
                    case "weather":
                        return GetWeatherInfo(commands[1]);
                        break;
                    case "start":
                        return OpenApplication(commands);
                        break;
                    case "move":
                        return MoveCursor();
                        break;
                    case "process":
                        return GetRunningProcesses(commands[1]);
                        break;
                    case "direction":
                        return GetDirectionsFor(commands[1], commands[2]);
                        break;
                    case "person":
                        CreatePerson(commands[1], commands[2], commands[3], currentClient);
                        return "Added";
                        break;
                    default:
                        return "Command could not be recognized";
                        break;
                }

            }
            return "Command could not be parsed";

        }

        public static void CreatePerson(string firstname, string lastname, string birthday, MyTcpClient currentClient)
        {
            Person p = new Person { FirstName = firstname, LastName = lastname, Birthday = DateTime.Parse(birthday) };
            SendMessage(JsonConvert.SerializeObject(p), currentClient);
        }
        public static string MoveCursor()
        {
            var cursor = new System.Windows.Forms.Cursor(Cursor.Current.Handle);
            Random rnd = new Random();
            var width = SystemInformation.VirtualScreen.Width;
            var height = SystemInformation.VirtualScreen.Height;
            for (int i = 0; i < 10; i++)
            {
                System.Windows.Forms.Cursor.Position = new System.Drawing.Point(rnd.Next(0, width), rnd.Next(0, height));
                Thread.Sleep(500);
            }
            return "Cursor moved around..";
        }
        public static string GetWeatherInfo(string city)
        {
            WebRequest wreq = WebRequest.Create("http://api.openweathermap.org/data/2.5/weather?appid=e8cc9c00920799b86059b6e5f58f421c&q=" + city + "&units=metric");
            WebResponse res = wreq.GetResponse();//blocking

            StreamReader strr = new StreamReader(res.GetResponseStream());
            string msg = strr.ReadToEnd();
            res.Close();
            OpenWeather weather = JsonConvert.DeserializeObject<OpenWeather>(msg);
            DateTime sunrise = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(weather.Sys.Sunrise);
            DateTime sunset = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(weather.Sys.Sunset);
            string weatherinfo = "in " + weather.Name + " the temperature is " + weather.Main.Temp + " degrees celcius, the current conditions are " + weather.Weather.First().Description + " sunrise is at " + sunrise.ToLocalTime().ToShortTimeString() + " sunset is at " + sunset.ToLocalTime().ToShortTimeString();
            return weatherinfo;
        }
        public static string GetRunningProcesses(string containsString)
        {
            Process[] processes = Process.GetProcesses();
            string prc = "";
            foreach (Process p in processes.Where(x => x.ProcessName.Contains(containsString)))
            {
                prc += p.ProcessName + Environment.NewLine;
            }
            return prc;
        }

        public static string OpenApplication(string[] commands)
        {

            if (commands.Length >= 2)
            {
                ProcessStartInfo psi = new ProcessStartInfo(commands[1], null);
                Process.Start(psi);
                return "Opened " + commands[1];
            }
            return "Nothing was opened";
        }

        public static string GetDirectionsFor(string destination, string origin)
        {

            WebClient client = new WebClient();
            string json = client.DownloadString("http://maps.googleapis.com/maps/api/directions/json?origin=" + origin + "&destination=" + destination + "&sensor=false&units=metric");
            var routes = JsonConvert.DeserializeObject<Directions>(json);
            string msg = "";
            msg += routes.Routes[0].Legs[0].Distance.Text;

            return msg;
        }

    }

}
