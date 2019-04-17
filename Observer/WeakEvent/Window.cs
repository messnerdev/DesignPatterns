using System;
using System.Windows;

namespace Observer.WeakEvent
{
    public class Window
    {
        public Window(Button button)
        {
            // If we do this we must make sure we remove it as well to properly garbage collect
            // button.Clicked += ButtonClicked;

            // Not available in .NET Core (from WindowsBase package)
            WeakEventManager<Button, EventArgs>.AddHandler(button, "Clicked", ButtonClicked);
        }

        private void ButtonClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button clicked (Window handler)");
        }

        ~Window()
        {
            Console.WriteLine("Window finalized");
        }
    }
}