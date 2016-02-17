using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory.BusinessEntity;
using Nancy.ModelBinding;

namespace Inventory.Web.Modules
{
    public class InventoryModule : NancyModule
    {
        #region Members

        private IProductRepository _productRepository;

        #endregion

        #region Constructor

        public InventoryModule(IProductRepository productRepository)
        {
            Get["/Product/{id}/"] = parameter =>
            {
                ProductEntity product = this.Bind<ProductEntity>();

                this._productRepository = productRepository;
                product = this._productRepository.Get(parameter.id);

                return Response.AsJson<ProductEntity>(product, HttpStatusCode.OK);
            };


            Post["/Product/{id}/{description}/{price}"] = parameter =>
            {

                ProductEntity product = this.Bind<ProductEntity>();

                product.Id = parameter.id;
                product.Description = parameter.description;
                product.Price = parameter.price;

                this._productRepository = productRepository;
                this._productRepository.Save(product);

                return Negotiate.WithView("Inventory").WithModel(product);
            };
        }

        #endregion
    }
}