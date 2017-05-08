using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Api.Tests.Ninject;
using Store.Api.Controllers;
using Ninject;
using System.Threading.Tasks;
using Store.BL.UnityOfWork;
using System.Web.Http.Results;
using Store.Api.Models;

namespace Store.Api.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest : DependencyInjectedTest
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly ProductsController _controller;

        public ProductsControllerTest()
        {
            NewScope();
            _controller = Kernel.Get<ProductsController>();
            NewScope();
            _unityOfWork = Kernel.Get<IUnityOfWork>();
        }

        [TestMethod]
        public async Task GetProducts_IsNotNull()
        {
            var result = await _controller.GetProducts();

            Assert.IsNotNull(result, "Result is null");
        }

        [TestMethod]
        public async Task GetProduct_IsNotNull()
        {
            var product = await _unityOfWork.Products.GetAllAsync();
            var idProduct = product.FirstOrDefault().Id;

            var result = await _controller.GetProduct(idProduct) as OkNegotiatedContentResult<ProductJsonModel>;

            Assert.IsNotNull(result, "Result is null");
            Assert.AreEqual(idProduct, result.Content.Id, "Id products is not equal");
        }

        [TestMethod]
        public async Task GetProduct_IsNull()
        {
            var fakeId = new Random().Next(1000000, 100000000);

            var result = await _controller.GetProduct(fakeId) as OkNegotiatedContentResult<ProductJsonModel>;

            Assert.IsNull(result, "Result is null");
        }
    }
}
