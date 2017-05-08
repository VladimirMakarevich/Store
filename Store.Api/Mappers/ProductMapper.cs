using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.DAL.Entities;
using Store.Api.Models;

namespace Store.Api.Mappers
{
    public class ProductMapper
    {
        private IMapper _mapper;

        public ProductMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<ProductJsonModel> ToProductListJsonModel(IEnumerable<Product> products)
        {
            var productListJsonModel = products.Select(ToProductJsonModel).ToList();

            return productListJsonModel;
        }

        public ProductJsonModel ToProductJsonModel(Product product)
        {
            return _mapper.Map<Product, ProductJsonModel>(product);
        }
    }
}