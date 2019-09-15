using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using ClayBackendCase.API.Presenters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Controllers
{    
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AccountsController : BaseController
    {
        private readonly IRegisterUserUseCase _registerUserUseCase;
        private readonly ILoginUseCase _loginUseCase;
        private readonly IGetUsersUseCase _getUsersUseCase;
        private readonly LoginPresenter _loginPresenter;
        private readonly RegisterUserPresenter _registerUserPresenter;
        private readonly GetUsersPresenter _getUsersPresenter;
        private readonly GetUserPresenter _getUserPresenter;

        public AccountsController(
            IRegisterUserUseCase registerUserUseCase,
            ILoginUseCase loginUseCase,
            IGetUsersUseCase getUsersUseCase,
            LoginPresenter loginPresenter,
            RegisterUserPresenter registerUserPresenter,
            GetUsersPresenter getUsersPresenter,
            GetUserPresenter getUserPresenter
        )
        {
            _registerUserUseCase = registerUserUseCase;
            _loginUseCase = loginUseCase;
            _getUsersUseCase = getUsersUseCase;
            _loginPresenter = loginPresenter;
            _registerUserPresenter = registerUserPresenter;
            _getUsersPresenter = getUsersPresenter;
            _getUserPresenter = getUserPresenter;
        }

        /// <summary>
        /// Return auth token for a specified user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "username": "string",
        ///        "password": "string"
        ///     }
        ///
        /// </remarks>        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {            
            await _loginUseCase.Handle(new LoginRequest(request.UserName, request.Password), _loginPresenter);

            return _loginPresenter.Result;
        }

        /// <summary>
        /// Registers a user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "firstname": "string",
        ///        "lastname": "string",
        ///        "username": "string",
        ///        "password": "string"
        ///     }
        ///
        /// </remarks>
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            await _registerUserUseCase.Handle(
                new RegisterUserRequest(request.FirstName, request.LastName, request.UserName, request.Password),
                _registerUserPresenter
            );

            return _registerUserPresenter.Result;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            await _getUsersUseCase.Handle(new GetUsersRequest(), _getUsersPresenter);

            return _getUsersPresenter.Result;
        }


        /// <summary>
        /// Gets a specified user.
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {            
            await _getUsersUseCase.Handle(new GetUsersRequest(id), _getUserPresenter);

            return _getUserPresenter.Result;
        }
    }
}
