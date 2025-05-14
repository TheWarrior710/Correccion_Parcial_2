using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_Scripting_Correccion
{
    public abstract class Composite : Node
    {
        protected List<Node> children = new List<Node>();

        public void AddChild(Node child)
        {
            if (child is Root)
                throw new InvalidOperationException("Composite nodes cannot have Root as child.");
            children.Add(child);
        }
    }
}
