using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_Scripting_Correccion
{
    public class Sequence : Composite
    {
        public override bool Execute()
        {
            foreach (var child in children)
            {
                if (!child.Execute()) return false;
            }
            return true;
        }
    }

}
