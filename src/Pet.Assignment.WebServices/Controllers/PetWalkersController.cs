using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Pet.Assignment.Abstractions;

namespace Pet.Assignment.WebServices.Controllers
{
    public class PetWalkersController : ApiController
    {
        private readonly IPetWalkerPetOwnerQuery _petWalkerPetOwnerQuery;

        public PetWalkersController(IPetWalkerPetOwnerQuery petWalkerPetOwnerQuery)
        {
            _petWalkerPetOwnerQuery = petWalkerPetOwnerQuery;
        }

        [HttpGet]
        [Route("api/petwalkers/IsApproved/{id}")]
        public async Task<IHttpActionResult> IsApproved(int id, int petId)
        {
            try
            {
                return Ok(await _petWalkerPetOwnerQuery.IsApproved(id, petId));
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, new object());
            }
        }
    }
}
