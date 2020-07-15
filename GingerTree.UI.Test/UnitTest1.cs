using Core.Domain;
using GingerTree.UI.Infrastructure.Dispatcher;
using GingerTree.UI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Windows.Documents;

namespace GingerTree.UI.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateElementViewModelFromDomain()
        {
            var elem = new Element("First") { Params = new List<Param>{new Param("place","banana") } };
            var vm = ElementViewModel.CreateFromDomain(elem);

            Assert.AreEqual(elem.Title, vm.Title);
            Assert.AreEqual(elem.Params.Count, vm.Params.Count);
        }


    }
}
