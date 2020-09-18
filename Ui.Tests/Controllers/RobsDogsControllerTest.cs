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
		private readonly RobsDogsController _rdc;

		private readonly Mock<IDogOwnerViewModelMapper> mockViewModelWrapper = new Mock<IDogOwnerViewModelMapper>();
		private readonly Mock<IDogOwnerService> mockDogOwnerService = new Mock<IDogOwnerService>();
		private readonly Mock<IDogOwnerRepository> mockDogsOwnerRepo = new Mock<IDogOwnerRepository>();

		public RobsDogsControllerTest()
		{
			_rdc = new RobsDogsController(mockViewModelWrapper.Object);
		}

		[TestMethod]
		public void RobsDogsController_Index_GetAllDogOwners_Test()
		{

			// Arrange

			var ownerName = "Rob";
				var	dogNames = new List<string>() { "Willow", "Nook", "Sox" }
				
	
			List<DogOwnerViewModel> testDogOwnerViewModels = new List<DogOwnerViewModel>()
			{
				new DogOwnerViewModel(){DogNames=dogNames,OwnerName =ownerName}
			}
			DogOwnerListViewModel testviewModel = new DogOwnerListViewModel() {
				DogOwnerViewModels = testDogOwnerViewModels
			};
			mockViewModelWrapper.Setup(x => x.GetAllDogOwners()).Returns(testviewModel);

			var mockContext = new Mock<ControllerContext>();
			RobsDogsController controller = new RobsDogsController();

			var controller = new RobsDogsController(mockViewModelWrapper.Object)
			{
				ControllerContext = mockContext.Object
			};

			// act
			var result = controller.Index as ViewResult;
			var resultData = (DogOwnerListViewModel)result.ViewData.Model;

			// assert
			Assert.AreEqual("Index", result.ViewName);
			Assert.AreEqual(ownerName, resultData.DogOwnerViewModels[0].OwnerName);
			Assert.AreEqual(dogNames, resultData.Last);
			Assert.AreEqual(expectedContact.Email, resultData.Email);
			//Act
			var result = controller.Index();
			ViewResult viewresult = _rdc.Index() as ViewResult;



			//			List<DogOwner> dogOwnerList = new List<DogOwner>
			//			{
			//				new DogOwner
			//				{
			//					OwnerName = "Rob",
			//					DogNames = new List<string>(){"Willow" , "Nook", "Sox" }
			//				}
			//			};






			//			mockDogsOwnerRepo.Setup(x => x.GetAllDogOwners()).Returns(dogOwnerList);
			//mockDogOwnerService.Setup(x => x.GetAllDogOwners()).Returns(dogOwnerList);

			//			mockViewModelWrapper.Setup(x => x.GetAllDogOwners()).Returns(mockDogOwnerService.Object);
			//			// Act
			//			ViewResult result = _rdc.Index() as ViewResult;


			// Assert
			Assert.IsNotNull(result);
			_rdc.Index();
			

			// Should be testing/verifying call to GetAllDogOwners and subsequent methods down the stack.
			// Moq is installed to help you.
		}
	}
}