using System.Collections.Generic;

namespace ClayBackendCase.API.Core.Dto.Repository
{
    public class RepositoryBaseResponse
    {
        public bool Success { get; }
        public string Error { get; }

        protected RepositoryBaseResponse(bool success = false, string error = null)
        {
            Success = success;
            Error = error;
        }
    }
}
