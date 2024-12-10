using LibraryAPI.ActionClass.Account;
using LibraryAPI.ActionClass.HelperClass.DTO;
using LibraryAPI.Interfes;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _IuserRepository;
        public UserController(IUserRepository iuserRepository) => _IuserRepository = iuserRepository;

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<AccountDTO>> Get() => await Task.FromResult(_IuserRepository.GetUser());

        [HttpGet("user/{login}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<AccountDTO>> Get(string login) => await Task.FromResult(_IuserRepository.GetUser(login));

        [HttpDelete("user/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<string>>> Delete(long id) => await Task.FromResult(_IuserRepository.DeleteUser(id));

        [HttpPost("user/addAccount")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<List<string>>> Post(AccountCreate userData) => await Task.FromResult(_IuserRepository.AddAccount(userData));

        [HttpPatch("user/updateUser")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<string>>> Patch(string login, AccountDTO user) => await Task.FromResult(_IuserRepository.UpdateUser(login, user));
    }
}
