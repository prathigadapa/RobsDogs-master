using System.Collections.Generic;
using System.Linq;
using Ui.Models;
using Ui.Services;

namespace Ui.ViewModelMappers
{
    public class DogOwnerViewModelMapper : IDogOwnerViewModelMapper
	{
		private readonly IDogOwnerService _dogOwnerService;
		public DogOwnerViewModelMapper(IDogOwnerService dogOwnerService)
		{
			_dogOwnerService = dogOwnerService;
		}
		public DogOwnerListViewModel GetAllDogOwners()
		{
			//var dogOwnerService = new DogOwnerService();
			var dogOwners = _dogOwnerService.GetAllDogOwners();
			var dogOwnerListViewModel = new DogOwnerListViewModel
			{
				DogOwnerViewModels = dogOwners.Select(e => new DogOwnerViewModel
				{
					OwnerName = e.OwnerName,
					DogNames = e.DogNames

				}).ToList()
			};

			return dogOwnerListViewModel;
		}
	}
}