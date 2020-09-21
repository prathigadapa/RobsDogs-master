using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ui.Controllers;
using Ui.Data;
using Ui.ViewModelMappers;
using Ui.Services;
using Ui.Entities;
using Ui.Models;
using System.Collections.Generic;
using Moq;
using System.Linq;

namespace Ui.Tests.Controllers
{
    [TestClass]
    public class RobsDogsControllerTest
    {


        private readonly Mock<IDogOwnerViewModelMapper> mockViewModelMapper = new Mock<IDogOwnerViewModelMapper>();
        
     


        [TestMethod]
        public void GetAllDogOwners_Should_Get_DogOwnerViewModel_From_DogOwnerViewModelMapper_And_Return_Index_View()
        {

            // Arrange

            string ownerName = "Rob";
            var dogNames = new List<string>() { "Willow", "Nook", "Sox" };


            List<DogOwnerViewModel> testDogOwnerViewModels = new List<DogOwnerViewModel>()
            {
                new DogOwnerViewModel(){DogNames=dogNames,OwnerName =ownerName}
            };
            DogOwnerListViewModel testviewModel = new DogOwnerListViewModel()
            {
                DogOwnerViewModels = testDogOwnerViewModels
            };
            mockViewModelMapper.Setup(x => x.GetAllDogOwners()).Returns(testviewModel);

            var mockContext = new Mock<ControllerContext>();


            var controller = new RobsDogsController(mockViewModelMapper.Object)
            {
                ControllerContext = mockContext.Object
            };

            // act
            var result = controller.Index() as ViewResult;
            var resultData = (DogOwnerListViewModel)result.ViewData.Model;
            var resultDogOwnerViewModel = resultData.DogOwnerViewModels[0];

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(resultData.DogOwnerViewModels.Count, 1);
            Assert.AreEqual(ownerName, resultDogOwnerViewModel.OwnerName, true);
            Assert.AreEqual(dogNames, resultDogOwnerViewModel.DogNames);



            // Should be testing/verifying call to GetAllDogOwners and subsequent methods down the stack.
            // Moq is installed to help you.
        }
    }
}