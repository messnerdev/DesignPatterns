namespace Decorator.MultipleInheritance
{
    /// <summary>
    /// Dragon is wrapper for a Bird Lizard
    /// </summary>
    public class Dragon : IBird, ILizard
    {
        private readonly Bird _bird = new Bird();
        private readonly Lizard _lizard = new Lizard();
        private int _weight;

        public void Fly()
        {
            _bird.Fly();
        }

        public void Crawl()
        {
            _lizard.Crawl();
        }

        // Way to handle multiple Interfaces with equal-named members
        public int Weight
        {
            get => _weight;
            set
            {
                _bird.Weight = value;
                _lizard.Weight = value;
                _weight = value;
            }
        }
    }

    // Not supported in C# :(
    //public class Dragon : Bird, Lizard
    //{

    //}
}