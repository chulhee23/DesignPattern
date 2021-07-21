using System;

namespace Observer
{
    class Subject {
        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver o){
            observers.Add(o);
        }

        public void NotifyObservers(){
            foreach (var o in observes)
            {
                o.Update();
            }
        }
    }

    interface IObserver{
        void Update();
    }

    class ObserverA : IObserver{
        public void Update(){
            // update ObserverA object
        }
    }
    class ObserverB : IObserver{
        public void Update(){
            // update ObserverB object
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
