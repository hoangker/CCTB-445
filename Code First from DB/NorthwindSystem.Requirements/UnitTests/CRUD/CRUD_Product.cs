using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TIN ADDED
using NorthwindSystem.BLL; //for acess to my system
using NorthwindSystem.Entities; // for my EF entities
using Xunit;
using Xunit.Extensions;

namespace NorthwindSystem.Requirements.UnitTests.CRUD
{
    public class CRUD_Product
    {

        [Fact]
        [AutoRollback] //Undo DB changes after test
        public void Should_Add_Product()
        {
            //Arrange
            var sut = new NorthwindManager();
            var product = new Product()
            {
                ProductName = "MSP Basic Product",
                Discontinued = false
            };

            //Act
            
            var productID = sut.AddProduct(product);
            //Assert
            Assert.True(productID > 0);
            Product actual = sut.GetProduct(productID);
            Assert.Equal(productID, actual.ProductID);
        }

        #region Properties for test Data
        //backing field
        private static IEnumerable<object[]> _CurrentProducts = null;
        public static IEnumerable<object[]> CurrentProducts
        {
            get
            {
                if (_CurrentProducts == null) //lazy-loading
                {
                    var controller = new NorthwindManager();
                    var temp = new List<object[]>();// empty list
                    foreach (Product company in controller.ListProducts())
                    {
                        temp.Add(new object[] { company });
                    }
                    _CurrentProducts = temp;
                }
                return _CurrentProducts;
            }
        }
        #endregion
        [Theory] //indicates that this is a test with (potentially) external data
        [PropertyData("CurrentProducts")]
        [AutoRollback]
        public void Should_Update_Products(Product existing)
        {
            //Arrange
            existing.ProductName = "TIN'S OLD PRODUCT";
            var sut = new NorthwindManager();

            //Act
            sut.UpdateProduct(existing);

            //Assert
            var actual = sut.GetProduct(existing.ProductID);
            Assert.NotNull(actual);
            Assert.Equal(existing.ProductName, actual.ProductName);
            
        }

        [Fact]
        [AutoRollback]
        public void Should_Delete_Products()
        { 
            //Arrange
            var sut = new NorthwindManager();
            var actual = new Product()
            {
                ProductName = "Product to delete"
            };
            actual.ProductID = sut.AddProduct(actual);

            //Act
            sut.DeleteProduct(actual);
            //Assert
            Product p = sut.GetProduct(actual.ProductID);

            Assert.Null(p);
        }

    }
}
