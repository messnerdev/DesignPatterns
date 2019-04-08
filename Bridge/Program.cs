using Autofac;

// Avoid cartesian product entity explosion
// Decouples an interface hierarchy from implementation
namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            BridgePattern();
            BridgePatternWithDI();
        }

        public static void BridgePattern()
        {
            IRenderer renderer = new RasterRenderer();
            var circle = new Circle(renderer, 5);

            circle.Draw();
            circle.Resize(2);
            circle.Draw();
        }

        public static void BridgePatternWithDI()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<VectorRenderer>().As<IRenderer>()
                .SingleInstance();

            // Adapt Circle constructor to allow positional argument for radius
            cb.Register((c, p) => 
                new Circle(c.Resolve<IRenderer>(), p.Positional<float>(0))
            );

            using (IContainer container = cb.Build())
            {
                Circle circle = container.Resolve<Circle>(
                    new PositionalParameter(0, 5.0f)
                );

                circle.Draw();
                circle.Resize(2);
                circle.Draw();
            }
        }
    }
}
