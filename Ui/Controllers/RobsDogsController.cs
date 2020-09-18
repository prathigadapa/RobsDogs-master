using System.Web.Mvc;
using Ui.ViewModelMappers;

namespace Ui.Controllers
{
    //https://www.youtube.com/watch?v=9ZvDBSQa_so
    public class RobsDogsController : Controller
    {
        private readonly IDogOwnerViewModelMapper _dogOwnerViewModelMapper;
        public RobsDogsController(IDogOwnerViewModelMapper dogOwnerViewModelMapper)
        {
            _dogOwnerViewModelMapper = dogOwnerViewModelMapper;
        }
        // GET: RobsDogs
        public ActionResult Index()
        {

			//var dogOwnerViewModelMapper = new DogOwnerViewModelMapper();
	        var dogOwnerListViewModel = _dogOwnerViewModelMapper.GetAllDogOwners();

            return View(dogOwnerListViewModel);
        }
    }
}