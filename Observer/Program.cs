using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Observer.EventKeyword;
using Observer.ObservablePropertiesAndSequences;
using Observer.WeakEvent;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            EventKeywordExample();
            WeakEventPatternExample();
            ObservablePropertiesAndSequencesExample();
        }

        private static void EventKeywordExample()
        {
            // Local function
            void CallDoctor(object sender, FallsIllEventArgs e)
            {
                Console.WriteLine($"A doctor has been called to {e.Address}");
            }

            var person = new Person();

            // Start observing
            person.FallsIll += CallDoctor;
            person.CatchACold();

            // Stop observing
            person.FallsIll -= CallDoctor;
            person.CatchACold();
        }

        private static void WeakEventPatternExample()
        {
            var button = new Button();
            var window = new Window(button);
            WeakReference windowRef = new WeakReference(window);
            button.Fire();

            // Attempt to garbage collect/finalize window
            Console.WriteLine("Setting window to null");
            window = null;

            FireGC();

            // Something is wrong here... Should be false
            Console.WriteLine($"Is the window alive after GC? {windowRef.IsAlive}");
        }

        private static void FireGC()
        {
            Console.WriteLine("Starting GC");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Console.WriteLine("Ending GC");
        }

        private static void ObservablePropertiesAndSequencesExample()
        {
            var market = new Market();
            market.Prices.ListChanged += (sender, args) =>
            {
                if (args.ListChangedType == ListChangedType.ItemAdded)
                {
                    double price = ((BindingList<double>) sender)[args.NewIndex];
                    Console.WriteLine($"BindingList got a price of {price}");
                }
            };

            market.AddPrice(123);
        }
    }
}
