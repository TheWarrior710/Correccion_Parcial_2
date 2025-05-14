using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_Scripting_Correccion
{
    using System;

    public class BehaviourTree
    {
        private Root root;

        public BehaviourTree(Root root)
        {
            this.root = root ?? throw new ArgumentNullException("root");
        }

        public bool Execute()
        {
            return root.Execute();
        }
    }

}
