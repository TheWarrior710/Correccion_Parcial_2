using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Taller2_Scripting_Correccion;


namespace BehaviourTree.Tests
{
    [TestFixture]
    public class BehaviourTreeTests
    {
        [Test]
        public void Root_WithNullChild_ReturnsFalse()
        {
            var root = new Root(null);
            var tree = new BehaviourTreeEngine(root);
            Assert.IsFalse(tree.Execute());
        }

        [Test]
        public void ParCheckTask_ReturnsTrue_IfEven()
        {
            var task = new ParCheckTask(4);
            Assert.IsTrue(task.Execute());
        }

        [Test]
        public void ParCheckTask_ReturnsFalse_IfOdd()
        {
            var task = new ParCheckTask(3);
            Assert.IsFalse(task.Execute());
        }

        [Test]
        public void Composite_CannotHaveRootAsChild()
        {
            var rootChild = new Root(new ParCheckTask(2));
            var sequence = new Sequence();
            Assert.Throws<InvalidOperationException>(() => sequence.AddChild(rootChild));
        }

        [Test]
        public void Root_CannotHaveAnotherRootAsChild()
        {
            var childRoot = new Root(new ParCheckTask(2));
            Assert.Throws<InvalidOperationException>(() => new Root(childRoot));
        }

        [Test]
        public void Sequence_AllChildrenPass_ReturnsTrue()
        {
            var seq = new Sequence();
            seq.AddChild(new ParCheckTask(2));
            seq.AddChild(new ParCheckTask(4));

            var tree = new BehaviourTreeEngine(new Root(seq));
            Assert.IsTrue(tree.Execute());
        }

        [Test]
        public void Sequence_OneFails_ReturnsFalse()
        {
            var seq = new Sequence();
            seq.AddChild(new ParCheckTask(2));
            seq.AddChild(new ParCheckTask(3));

            var tree = new BehaviourTreeEngine(new Root(seq));
            Assert.IsFalse(tree.Execute());
        }

        [Test]
        public void Selector_FirstSucceeds_SkipsOthers()
        {
            var sel = new Selector();
            sel.AddChild(new ParCheckTask(2));
            sel.AddChild(new ParCheckTask(4));

            var tree = new BehaviourTreeEngine(new Root(sel));
            Assert.IsTrue(tree.Execute());
        }

        [Test]
        public void Selector_AllFail_ReturnsFalse()
        {
            var sel = new Selector();
            sel.AddChild(new ParCheckTask(1));
            sel.AddChild(new ParCheckTask(3));

            var tree = new BehaviourTreeEngine(new Root(sel));
            Assert.IsFalse(tree.Execute());
        }
    }

}
