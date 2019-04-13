namespace Proxy.Property
{
    public class PropertyCreature
    {
        private readonly Property<int> _agility = new Property<int>();

        public int Agility
        {
            get => _agility.Value;
            set => _agility.Value = value;
        }
    }
}