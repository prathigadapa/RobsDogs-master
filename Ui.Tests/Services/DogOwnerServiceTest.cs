using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ui.Data;
using Ui.ViewModelMappers;
using Ui.Services;
using Ui.Entities;
using Ui.Models;
using System.Collections.Generic;
using Moq;
using System.Linq;


namespace Ui.Tests.Services
{
    [TestClass]
    public class DogOwnerServiceTest
    {
       
        private readonly Mock<IDogOwnerRepository> mockDogOwnerRepo = new Mock<IDogOwnerRepository>();


        [TestMethod]
        public void GetAllDogOwners_Test()
        {
            // Arrange
            List<DogOwner> dogOwnerList = new List<DogOwner>
                        {
                            new DogOwner
                            {
                                OwnerName = "Rob",
                                DogNames = new List<string>(){"Willow" , "Nook", "Sox" }
                            }
                    };


            mockDogOwnerRepo.Setup(x => x.GetAllDogOwners()).Returns(dogOwnerList);

            DogOwnerService service = new DogOwnerService(mockDogOwnerRepo.Object);

            // act

            var result = service.GetAllDogOwners();

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(dogOwnerList[0].OwnerName, result[0].OwnerName, true);
            Assert.AreEqual(dogOwnerList[0].DogNames, result[0].DogNames);

        }
    }
}
