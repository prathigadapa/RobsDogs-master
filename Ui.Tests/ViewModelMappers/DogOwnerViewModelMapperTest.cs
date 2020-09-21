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


namespace Ui.Tests.ViewModelMappers
{
    [TestClass]
    public class DogOwnerViewModelMapperTest
    {
        private readonly Mock<IDogOwnerService> mockDogOwnerService = new Mock<IDogOwnerService>();
        [TestMethod]
        public void GetAllDogOwners_Should_Get_Listof_DogOwner_From_DogOwnerService()
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


            mockDogOwnerService.Setup(x => x.GetAllDogOwners()).Returns(dogOwnerList);

            DogOwnerViewModelMapper viewModel = new DogOwnerViewModelMapper(mockDogOwnerService.Object);

            // act

            var result = (DogOwnerListViewModel)viewModel.GetAllDogOwners();

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual( dogOwnerList[0].OwnerName, result.DogOwnerViewModels[0].OwnerName, true);
            Assert.AreEqual(dogOwnerList[0].DogNames, result.DogOwnerViewModels[0].DogNames);

            
        }
    }
}
