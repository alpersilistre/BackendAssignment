using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using ClayBackendCase.API.Presenters.Locks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LocksController : BaseController
    {
        private readonly IGetLocksUseCase _getLocksUseCase;
        private readonly ICreateLockUseCase _createLockUseCase;
        private readonly ILockingUseCase _lockingUseCase;
        private readonly GetLocksPresenter _getLocksPresenter;
        private readonly GetLockPresenter _getLockPresenter;
        private readonly CreateLockPresenter _createLockPresenter;
        private readonly LockingPresenter _lockingPresenter;

        public LocksController(
            IGetLocksUseCase getLocksUseCase,
            ICreateLockUseCase createLockUseCase,
            ILockingUseCase lockingUseCase,
            GetLocksPresenter getLocksPresenter,
            GetLockPresenter getLockPresenter,
            CreateLockPresenter createLockPresenter,
            LockingPresenter lockingPresenter
            )
        {
            _getLocksUseCase = getLocksUseCase;
            _createLockUseCase = createLockUseCase;
            _lockingUseCase = lockingUseCase;
            _getLocksPresenter = getLocksPresenter;
            _getLockPresenter = getLockPresenter;
            _createLockPresenter = createLockPresenter;
            _lockingPresenter = lockingPresenter;
        }

        /// <summary>
        /// Gets all locks.
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetLocks()
        {            
            await _getLocksUseCase.Handle(new GetLocksRequest(), _getLocksPresenter);

            return _getLocksPresenter.Result;
        }

        /// <summary>
        /// Gets a specified lock.
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "Admin, User")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLock(int id)
        {
            await _getLocksUseCase.Handle(new GetLocksRequest(id), _getLockPresenter);

            return _getLockPresenter.Result;
        }

        /// <summary>
        /// Creates a lock.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "name": "string",
        ///        "companyid": "number"
        ///     }
        ///
        /// </remarks>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateLock([FromBody] CreateLockRequest request)
        {
            await _createLockUseCase.Handle(new CreateLockRequest(request.Name, request.CompanyId), _createLockPresenter);

            return _createLockPresenter.Result;
        }

        /// <summary>
        /// Locks or unlocks a specified lock.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "isLocked": boolean,
        ///     }
        ///
        /// </remarks>
        /// <param name="id"></param>
        [Authorize(Roles = "Admin, User")]
        [HttpPatch("{id}/locking")]
        public async Task<IActionResult> Locking(int id, [FromBody] LockingRequest request)
        {
            await _lockingUseCase.Handle(new LockingRequest(id, request.IsLocked, GetUserId()), _lockingPresenter);

            return _lockingPresenter.Result;
        }
    }
}
