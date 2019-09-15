﻿using ClayBackendCase.API.Core.Dto.UseCaseRequest;
using ClayBackendCase.API.Core.Dto.UseCaseResponses;

namespace ClayBackendCase.API.Core.Interfaces.UseCases
{
    public interface IGetUsersUseCase : IUseCaseRequestHandler<GetUsersRequest, GetUsersResponse>
    {
    }
}
