using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_Scripting_Correccion
{
    public class BehaviourTreeEngine
    {
        private Root root;

        public BehaviourTreeEngine(Root root)
        {
            this.root = root ?? throw new ArgumentNullException(nameof(root));
        }

        public bool Execute()
        {
            return root.Execute();
        }
    }
}
