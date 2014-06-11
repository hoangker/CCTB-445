using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TIN ADDED
using NorthwindSystem.BLL; //for acess to my system
using NorthwindSystem.Entities; // for my EF entities
using Xunit; // the core for testing
using Xunit.Extensions; //for Theories, AutoRollback, etc.

namespace NorthwindSystem.Requirements.UnitTests.CRUD
{
    public class CRUD_Shipper
    {
        [Fact]
        public void Should_Add_Numbers()
        { 
            // Arrange
            int first = 5, second = 7;
            // Act
            int actual = first + second;
            // Assert
            Assert.Equal(12, actual);

        }

        [Fact] //indicates that this is a test
        [AutoRollback] //Undo DB changes after test
        public void Should_Add()
        { 
            //Arrange
            var sut = new NorthwindManager(); // sut is short for "Situation Under Test"
            var expected = new Shipper()
            {
                CompanyName = "Tin Hoang's Transporter Service",
                Phone = "780.231.3123"
            };

            //Act
            var actualId = sut.AddShipper(expected);
            //Assert
            Assert.True(actualId > 0);
            Shipper actual = sut.GetShipper(actualId);
            Assert.Equal(expected.CompanyName, actual.CompanyName);
            Assert.Equal(expected.Phone,actual.Phone);
            Assert.Equal(actualId,actual.ShipperID);



        }
    }
}
