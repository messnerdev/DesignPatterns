namespace Builder
{
    public class Person
    {
        public string Name;
        public string Postition;

        public class Builder : PersonJobBuilder<Builder> { }

        public static Builder New => new Builder();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Postition)}: {Postition}";
        }
    }
}