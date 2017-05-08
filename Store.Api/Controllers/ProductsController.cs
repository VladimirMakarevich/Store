using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Store.DAL.Context;
using Store.DAL.Entities;
using Store.BL.UnityOfWork;
using Store.Api.Mappers;
using Store.Api.Models;

namespace Store.Api.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductsController : DefaultController
    {
        private ProductMapper _productMapper;

        public ProductsController(IUnityOfWork unityOfWork, ProductMapper productMapper)
            :base(unityOfWork)
        {
            _productMapper = productMapper;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IEnumerable<ProductJsonModel>> GetProducts()
        {
            IEnumerable<Product> products = await _unityOfWork.Products.GetAllAsync();
            IEnumerable<ProductJsonModel> productListJsonModel = _productMapper.ToProductListJsonModel(products);

            return productListJsonModel;
        }

        [HttpGet]
        [Route("GetProduct")]
        [ResponseType(typeof(ProductJsonModel))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await _unityOfWork.Products.GetAsync(id);
            ProductJsonModel productJsonModel = _productMapper.ToProductJsonModel(product);

            if (productJsonModel == null)
            {
                return NotFound();
            }

            return Ok(productJsonModel);
        }
    }
}