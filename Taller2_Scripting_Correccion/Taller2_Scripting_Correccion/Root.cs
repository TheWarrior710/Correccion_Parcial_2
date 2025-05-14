using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_Scripting_Correccion
{
    public class Root : Node
    {
        private Node child;

        public Root(Node child)
        {
            if (child is Root)
                throw new InvalidOperationException("Root cannot have another Root as child.");
            this.child = child;
        }

        public override bool Execute()
        {
            if (child == null) return false;
            return child.Execute();
        }
    }
}
