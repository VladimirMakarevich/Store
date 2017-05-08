using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Web.Tests.Ninject;
using Store.Web.Controllers;
using Ninject;
using System.Threading.Tasks;

namespace Store.Web.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest : DependencyInjectedTest
    {
        private ProductsController _controller;

        public ProductsControllerTest()
        {
            NewScope();
            _controller = Kernel.Get<ProductsController>();
        }

        [TestMethod]
        public async Task Get_IsNotNull()
        {
            var result = await _controller.GetProducts();

            Assert.IsNotNull(result, "Result is null");
        }
    }
}
