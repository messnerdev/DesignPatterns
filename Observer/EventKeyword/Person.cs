using System;

namespace Observer.EventKeyword
{
    public class Person
    {
        public void CatchACold()
        {
            FallsIll?.Invoke(this, 
                new FallsIllEventArgs(){ Address = "123 London Road" });
        }

        public event EventHandler<FallsIllEventArgs> FallsIll;
    }
}