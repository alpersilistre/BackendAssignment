using System.Collections.Generic;

namespace ClayBackendCase.API.Core.Dto.Repository
{
    public class CreateUserResponse : RepositoryBaseResponse
    {
        public string Id { get; }

        public CreateUserResponse(string id, bool success = false, string error = null) : base(success, error)
        {
            Id = id;
        }
    }
}
