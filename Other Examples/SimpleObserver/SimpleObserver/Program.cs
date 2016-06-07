using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleObserver
{
    /// <summary>
    /// Simple observer pattern implementation without interfaces or delegates
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Observer ob1 = new Observer { Name = "Knud" };
            Observer ob2 = new Observer() { Name="Jens" };
            SomethingToObserve so = new SomethingToObserve();
            so.Subscribe(ob1);
            so.Subscribe(ob2);
            so.StartSomeRandomWork();

        }
    }


    class Observer
    {
        public string Name { get; set; }
        
        /// <summary>
        /// The observed object will call this method when something changes on it
        /// </summary>
        public void Notify(string message)
        {
            Console.WriteLine("Notification recieved on ("+Name+"): " + message);
        }
    }
    class SomethingToObserve
    {
        public List<Observer> Observers { get; set; }
        public SomethingToObserve()
        {
            Observers = new List<Observer>();
        }

        public void StartSomeRandomWork()
        {
            //Haaard work!
            while (true)
            {
                Thread.Sleep(1000);
                NotifyObservers("I just waited 1 second"); 
            }
        }
        
        public void NotifyObservers(string message)
        {
            foreach (Observer obs in Observers)
            {
                obs.Notify("Hi " + obs.Name + " " + message);
            }
        }
        public void Subscribe(Observer obs)
        {
            Observers.Add(obs);
        }
        public void Unsubscribe(Observer obs)
        {
            Observers.Remove(obs);
        }
    }
}
