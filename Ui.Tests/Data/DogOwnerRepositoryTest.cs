using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ui.Data;
using Ui.Entities;
using Ui.Models;
using System.Collections.Generic;
using Moq;

namespace Ui.Tests.Data
{
    [TestClass]
    public class DogOwnerRepositoryTest
    {
        [TestMethod]
        public void GetAllDogOwners_Test()
        {
            //Assign
            string OwnerName = "Rob";
            var DogNames = new List<string>() { "Willow", "Nook", "Sox" };
            DogOwnerRepository repo = new DogOwnerRepository();
           
            //Act
            var result= repo.GetAllDogOwners();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(OwnerName, result[0].OwnerName, true);
           


        }
    }
}
