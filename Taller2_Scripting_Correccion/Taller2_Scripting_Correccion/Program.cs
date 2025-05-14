using System;
namespace Taller2_Scripting_Correccion

{
    class Program
    {
        static void Main()
        {
            var sequence = new Sequence();
            sequence.AddChild(new ParCheckTask(2));
            sequence.AddChild(new ParCheckTask(4));

            var root = new Root(sequence);
            var tree = new BehaviourTreeEngine(root);

            Console.WriteLine("Resultado del árbol: " + tree.Execute());
        }
    }

}
