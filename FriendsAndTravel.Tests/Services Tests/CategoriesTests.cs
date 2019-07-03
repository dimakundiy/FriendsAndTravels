using FriendsAndTravel.BAL.Interfaces;
using FriendsAndTravel.BAL.Services;
using FriendsAndTravel.Data.Entities;
using FriendsAndTravel.Data.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendsAndTravel.Tests.Services_Tests
{
    [TestFixture]
    public class CategoriesTests 
    {
        


        [Test]
        public void AddCategory_titleIsnOTEmpty_IsNoTEmpty() {
            var mock = new Mock<IUnitOfWork>();
            var service = new CategoryService(mock.Object);
            List<Categories> categories = new List<Categories>();
            categories.Add(
                new Categories() {
                    Id=1,
                    Tag = "dddd"
                }      
            );
            mock.Setup(u => u.CategoryRepository.GetAll()).Returns(categories);
            var result = service.Categories();
            Assert.IsNotEmpty(result);
        }
        
        
    }
}
