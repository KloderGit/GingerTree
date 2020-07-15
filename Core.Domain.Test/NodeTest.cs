using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml;

namespace Core.Domain.Test
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void CreateNodeFromElementAndCloneParams()
        {
            var element = new Element("Test Event");
            element.Params.Add(new Param("first", "firstValue"));

            var node = new Node(element);
            node.AddParam(new Param("second", "secondValue"));

            Assert.IsTrue(node.GetParams().Any(x=>x.Key == "first"));
            Assert.IsTrue(node.GetParams().Count() == 2);
        }

        [TestMethod]
        public void AddChildAsNewObject()
        {
            var node1 = new Domain.Node(new Element("dd")) { Id = 1 };
            var node2 = new Domain.Node(new Element("ff")) { Id = 2 };
            node1.AddChild(node2);

            Assert.AreNotEqual(node1.GetChildren().First().Id, 2);
            Assert.AreNotEqual(node1.GetChildren().First(), node2);
        }

        [TestMethod]
        public void AddedChildHasTheSameName()
        {
            var node1 = new Domain.Node(new Element("dd")) { Id = 1 };
            var element = new Element("Test Event");
            var node2 = new Node(element);
            node1.AddChild(node2);

            var addedNode = node1.GetChildren().First();

            Assert.AreEqual(addedNode.Title, node2.Title);
        }

        [TestMethod]
        public void AddedChildCopyingParams()
        {
            var node1 = new Domain.Node(new Element("dd")) { Id = 1 };
            var element = new Element("Test Event");
            element.Params.Add(new Param("first", "firstValue"));
            var node2 = new Node(element);
            node2.AddParam(new Param("second", "secondValue"));

            node1.AddChild(node2);

            var addedNode = node1.GetChildren().First();

            Assert.AreEqual(addedNode.GetParams().Count(), 2);
            Assert.IsTrue(addedNode.GetParams().Any(x=>x.Key == "first"));
            Assert.IsTrue(addedNode.GetParams().Any(x => x.Key == "second"));
        }

        [TestMethod]
        public void AddedChildIsCopy()
        {
            var node1 = new Domain.Node(new Element("dd")) { Id = 1 };

            var element = new Element("Test Event");
            element.Params.Add(new Param("first", "firstValue"));
            var node2 = new Node(element);
            node2.AddParam(new Param("second", "secondValue"));

            node1.AddChild(node2);

            var addedNode = node1.GetChildren().First();

            //Assert.AreEqual(addedNode.GetEvent(), node2.GetEvent());
            Assert.AreEqual(addedNode.GetParams().Count(), 2);
            Assert.AreEqual(addedNode.GetChildren().Count(), node2.GetChildren().Count());
        }

        [TestMethod]
        public void AddedChildHasCopiedChildren()
        {
            var node1 = new Domain.Node(new Element("dd"));
            var node2 = new Domain.Node(new Element("ff"));
            var node3 = new Domain.Node(new Element("cc"));
            var node4 = new Domain.Node(new Element("32"));
            node2.AddChild(node3);
            node2.AddChild(node4);
            node1.AddChild(node2);

            var firstLevelChild = node1.GetChildren().First();
            var secondLevelChild = firstLevelChild.GetChildren().First();

            Assert.AreEqual(node1.GetChildren().Count(), 1);
            Assert.AreEqual(firstLevelChild.GetChildren().Count(), 2);
            Assert.AreEqual(secondLevelChild.GetChildren().Count(), 0);
        }
    }
}
