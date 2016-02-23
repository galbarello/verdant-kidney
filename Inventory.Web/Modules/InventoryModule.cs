using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inventory.BusinessEntity;
using Nancy.ModelBinding;
using Inventory.Services.Abstractions;

namespace Inventory.Web.Modules
{
    public class InventoryModule : NancyModule
    {
        #region Constans

        private const String errorMessage = "Something bad happened";

        #endregion

        #region Members

        private IProductRepository _productRepository;
        private IProductService _productService;

        #endregion

        #region Constructor

        public InventoryModule(IProductRepository productRepository, IProductService productService)
        {
            Get["/Product/{id}/"] = parameter =>
            {
                Response response = null;

                try
                {
                    ProductEntity product = this.Bind<ProductEntity>();

                    this._productRepository = productRepository;
                    product = this._productRepository.Get(parameter.id);

                    response = Response.AsJson<ProductEntity>(product, HttpStatusCode.OK);
                }
                catch
                {
                    response = Response.AsJson<String>(errorMessage, HttpStatusCode.InternalServerError);
                }

                return response;
            };


            Post["/Product/"] = parameter =>
            {
                Response response = null;

                try
                {
                    ProductEntity product = this.Bind<ProductEntity>();

                    this._productService = productService;
                    this._productService.Create(product);

                    response = Response.AsJson<ProductEntity>(product, HttpStatusCode.Created);
                }
                catch
                {
                    response = Response.AsJson<String>(errorMessage, HttpStatusCode.InternalServerError);
                }

                return response;

            };

            Put["/Product/AddStock"] = parameter =>
            {
                Response response = null;

                try
                {
                    CommandStockInput cmdStock = this.Bind<CommandStockInput>();

                    this._productService = productService;
                    this._productService.AddStock(cmdStock);

                    response = Response.AsJson<Object>(HttpStatusCode.OK);
                }
                catch
                {
                    response = Response.AsJson<String>(errorMessage, HttpStatusCode.InternalServerError);
                }

                return response;
            };


            Put["/Product/RemoveStock"] = parameter =>
            {
                Response response = null;

                try
                {
                    CommandStockInput cmdStock = this.Bind<CommandStockInput>();

                    this._productService = productService;
                    this._productService.RemoveStock(cmdStock);

                    response = Response.AsJson<Object>(HttpStatusCode.OK);
                }
                catch
                {
                    response = Response.AsJson<String>(errorMessage, HttpStatusCode.InternalServerError);
                }

                return response;
            };

            Put["/Product/Archive"] = parameter =>
            {
                Response response = null;

                try
                {
                    CommandStockInput cmdStock = this.Bind<CommandStockInput>();

                    this._productService = productService;
                    this._productService.Archive(cmdStock.Id);

                    response = Response.AsJson<Object>(HttpStatusCode.OK);
                }
                catch
                {
                    response = Response.AsJson<String>(errorMessage, HttpStatusCode.InternalServerError);
                }

                return response;
            };

        }

        #endregion
    }
}