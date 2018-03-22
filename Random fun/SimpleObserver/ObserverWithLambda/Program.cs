using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverWithLambda
{
    /// <summary>
    /// In this example, the "Program" is the Observer, and a callback is added to the Observables collection of delegates (event)
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            SomethingToObserve so = new SomethingToObserve();
            so.OnStateChange += (source, e)=> {
                SomethingToObserve sender = (SomethingToObserve)source;
                Console.WriteLine("Callback recieved from the Observed item: " + sender.Name);
            };
            so.StartSomeRandomWork();
        }
    }

    public class SomethingToObserve
    {
        public string Name
        {
            get
            {
                return "John the observable man";
            }
        }
        public void StartSomeRandomWork()
        {
            //Haaard work!
            while (true)
            {
                Thread.Sleep(1000);
                NotifyObservers("The observed just waited 1 second");
            }
        }

        public void NotifyObservers(string message)
        {
            if (OnStateChange != null) //can be simplified, i know
                OnStateChange(this, new MyNewEventArguments(message));
        }

        /// <summary>
        /// Create a signature for the delegate allowed for the new event
        /// </summary>
        /// <param name="message"></param>
        public delegate void SomethingHappenedHandler(object source, MyNewEventArguments e);
        /// <summary>
        /// A local variable to hold the event
        /// </summary>
        public event SomethingHappenedHandler OnStateChange;
        
    }

    public class MyNewEventArguments : EventArgs
    {
        private string message;
        public MyNewEventArguments(string message)
        {
            this.message = message;
        }
    }

}


/*
 note to self
 public event SomethingHappenedHandler OnStateChange
        {
            add
            {
                changeEvent += value;
            }
            remove
            {
                changeEvent -= value;
            }
        }
     
     */
