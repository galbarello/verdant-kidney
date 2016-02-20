using Inventory.BusinessEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Logic.Test
{
    [TestClass]
    public class ProductLogicTest : TestClassBase<ProductLogic>
    {
        #region Members

        private ProductEntity _product;
        private Mock<IProductRepository> _productRepository;

        #endregion

        #region Methods

        [TestInitialize]
        public override void Initialize()
        {
            base.Initialize();
            this._productRepository = new Mock<IProductRepository>();
            this.Target = new ProductLogic(this._productRepository.Object);

            this._product = new ProductEntity()
            {
                Id = 1,
                Code = 100,
                Description = "Screwdriver",
                Price = 20.5M,
                Quantity = 10,
                IsActive = true
            };
        }

        #endregion

        [TestClass]
        public class TheAddStock_Method : ProductLogicTest
        {
            #region Methods

            [TestInitialize]
            public override void Initialize()
            {
                base.Initialize();
            }

            [TestMethod]
            public void Add_product_stock()
            {
                // Arrange
                CommandStockInput cmd = new CommandStockInput()
                {
                    Id = 1,
                    Quantity = 10
                };

                this._productRepository.Setup(r => r.Get(cmd.Id)).Returns(this._product);

                // Act
                this.Target.AddStock(cmd);

                // Assert
                Assert.AreEqual<Int32>(20, this._product.Quantity);
            }

            [TestMethod]
            [ExpectedException(typeof(NullReferenceException))]
            public void The_input_id_does_not_exist()
            {
                // Arrange
                CommandStockInput cmd = new CommandStockInput()
                {
                    Id = 2,
                    Quantity = 10
                };

                // Act
                this.Target.AddStock(cmd);

                // Assert
            }

            #endregion
        }

        [TestClass]
        public class TheRemoveStock_Method : ProductLogicTest
        {
            #region Methods

            [TestInitialize]
            public override void Initialize()
            {
                base.Initialize();
            }

            [TestMethod]
            public void Remove_product_stock()
            {
                // Arrange
                CommandStockInput cmd = new CommandStockInput()
                {
                    Id = 1,
                    Quantity = 10
                };

                this._productRepository.Setup(r => r.Get(cmd.Id)).Returns(this._product);

                // Act
                this.Target.RemoveStock(cmd);

                // Assert
                Assert.AreEqual<Int32>(0, this._product.Quantity);
            }

            [TestMethod]
            [ExpectedException(typeof(NullReferenceException))]
            public void The_input_id_does_not_exist()
            {
                // Arrange
                CommandStockInput cmd = new CommandStockInput()
               {
                   Id = 2,
                   Quantity = 10
               };

                // Act
                this.Target.RemoveStock(cmd);

                // Assert
            }

            #endregion
        }

        [TestClass]
        public class TheArchive_Method : ProductLogicTest
        {
            #region Methods

            [TestInitialize]
            public override void Initialize()
            {
                base.Initialize();
            }

            [TestMethod]
            public void Archive_a_product()
            {
                //Arrange
                Int32 id = 1;

                this._productRepository.Setup(r => r.Get(id)).Returns(this._product);

                //Act
                this.Target.Archive(id);

                // Assert
                Assert.IsFalse(this._product.IsActive);
            }

            [TestMethod]
            [ExpectedException(typeof(NullReferenceException))]
            public void The_input_id_does_not_exist()
            {
                // Arrange
                Int32 id = 2;

                // Act
                this.Target.Archive(id);

                // Assert
            }

            #endregion
        }
    }
}
