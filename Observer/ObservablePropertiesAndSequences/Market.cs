using System.ComponentModel;

namespace Observer.ObservablePropertiesAndSequences
{
    public class Market
    {
        public BindingList<double> Prices = new BindingList<double>();

        public void AddPrice(double price)
        {
            Prices.Add(price);
        }
    }
}