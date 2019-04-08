using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Composite.Graphics;
using Composite.Neurons;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            GraphicObjectsExample();
            NeuronExample();
        }

        public static void GraphicObjectsExample()
        {
            var drawing = new GraphicObject() { Name = "My Drawing" };
            drawing.Children.Add(new Square() { Color = "Red" });
            drawing.Children.Add(new Circle() { Color = "Yellow" });

            var group = new GraphicObject();
            group.Children.Add(new Square() { Color = "Blue" });
            group.Children.Add(new Circle() { Color = "Blue" });

            drawing.Children.Add(group);

            Console.WriteLine(drawing);
        }
        public static void NeuronExample()
        {
            var neuron1 = new Neuron();
            var neuron2 = new Neuron();

            var layer1 = new NeuronLayer();
            var layer2 = new NeuronLayer();

            // Neurons can connect to neurons
            // Neurons can connect to layers
            // Layers can connect to neurons
            // Layers can connect to layers
            neuron1.ConnectTo(neuron2);
            neuron1.ConnectTo(layer1);
            layer1.ConnectTo(layer2);
        }
    }
}

