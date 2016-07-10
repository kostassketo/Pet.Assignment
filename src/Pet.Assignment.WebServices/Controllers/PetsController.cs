using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Pet.Assignment.Abstractions;
using Pet.Assignment.Domain;
using Pet.Assignment.WebServices.DTOs;

namespace Pet.Assignment.WebServices.Controllers
{
    public class PetsController : ApiController
    {
        private readonly IQuery<Domain.Pet> _petQuery;
        private readonly IQuery<PetOwner> _petOwnerQuery;
        private readonly ICommand<Domain.Pet> _petCommand;

        public PetsController(IQuery<Domain.Pet> petQuery, IQuery<PetOwner> petOwnerQuery, ICommand<Domain.Pet> petCommand)
        {
            _petQuery = petQuery;
            _petOwnerQuery = petOwnerQuery;
            _petCommand = petCommand;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByOwner(int petOwnerId)
        {
            var petOwner = await _petOwnerQuery.GetAsync(x => x.Id == petOwnerId);
            if (petOwner == null)
            {
                return NotFound();
            }

            var pets = await _petQuery.GetAsync(x => x.PetOwners.FirstOrDefault(po => po.Id == petOwnerId).Id == petOwnerId);
            if (pets == null)
            {
                return NotFound();
            }

            var dtoPets = pets.Select(x => new PetDto {Id = x.Id, Name = x.Name, DateOfBirth = x.DateOfBirth}).ToList();
            return Ok(dtoPets);
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var pet = await _petQuery.GetAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            var dtoPets = new PetDto
            {
                Id = pet.Id,
                Name = pet.Name,
                DateOfBirth = pet.DateOfBirth
            };

            return Ok(dtoPets);
        }

        public async Task<IHttpActionResult> Post(Domain.Pet pet)
        {
            try
            {
                await _petCommand.Create(pet);
                return Content(HttpStatusCode.Created, pet);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, pet);
            }
        }

        public async Task<IHttpActionResult> Put(int id, [FromBody]Domain.Pet pet)
        {
            try
            {
                var petFound = await _petQuery.GetAsync(id);
                if (petFound == null)
                {
                    return NotFound();
                }

                petFound.Name = pet.Name;
                petFound.DateOfBirth = pet.DateOfBirth;
                petFound.PetOwners = pet.PetOwners;
                petFound.PetWalkers = pet.PetWalkers;

                await _petCommand.Update(petFound);
                return Ok(petFound);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, pet);
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetWithAgeBelow(int petAge)
        {
            var pets = await _petQuery.GetAsync(x => DateTime.Now.Year - x.DateOfBirth.Year < petAge);
            if (pets == null)
            {
                return NotFound();
            }

            var dtoPets = pets.Select(x => new PetDto { Id = x.Id, Name = x.Name, DateOfBirth = x.DateOfBirth }).ToList();

            return Ok(dtoPets);
        }
    }
}
