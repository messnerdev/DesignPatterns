using System.Collections.Generic;

namespace Composite.Neurons
{
    public static class NeuronExtensions
    {
        public static void ConnectTo(this IEnumerable<Neuron> self, IEnumerable<Neuron> other)
        {
            if (ReferenceEquals(self, other))
                return;

            foreach (Neuron selfNeuron in self)
            foreach (Neuron otherNeuron in other)
            {
                selfNeuron.Out.Add(otherNeuron);
                otherNeuron.In.Add(selfNeuron);
            }
        }
    }
}