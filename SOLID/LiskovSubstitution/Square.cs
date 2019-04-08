using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.LiskovSubstitution
{
    public class Square : Rectangle
    {
        // We need to override these properties (not new them) to get consistent behavior between Square and Rectangle instantiations of a Square
        public override int Width
        {
            set => base.Width = base.Height = value;
        }

        public override int Height
        {
            set => Width = value;
        }
    }
}
