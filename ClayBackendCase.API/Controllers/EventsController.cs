using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Interfaces.UseCases;
using ClayBackendCase.API.Presenters.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClayBackendCase.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class EventsController : BaseController
    {
        private readonly IGetEventsUseCase _getEventsUseCase;
        private readonly GetEventsPresenter _getEventsPresenter;

        public EventsController(
            IGetEventsUseCase getEventsUseCase,
            GetEventsPresenter getEventsPresenter
        )
        {
            _getEventsUseCase = getEventsUseCase;
            _getEventsPresenter = getEventsPresenter;
        }

        /// <summary>
        /// Gets all events.
        /// </summary>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            await _getEventsUseCase.Handle(new GetEventsRequest(), _getEventsPresenter);

            return _getEventsPresenter.Result;
        }
    }
}
