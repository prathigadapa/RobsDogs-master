
using Ui.Entities;
using System.Collections.Generic;
namespace Ui.Services
{
    public interface IDogOwnerService
    {
        List<DogOwner> GetAllDogOwners();
    }
}