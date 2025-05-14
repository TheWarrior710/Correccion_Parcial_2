using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_Scripting_Correccion
{
    public class ParCheckTask : Task
    {
        private int numero;

        public ParCheckTask(int numero)
        {
            this.numero = numero;
        }

        public override bool Execute()
        {
            return numero % 2 == 0;
        }
    }

}
