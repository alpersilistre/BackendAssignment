namespace ClayBackendCase.API.Core.Dto
{
    public class Token
    {
        public string Id { get; }
        public string AuthToken { get; }
        public string Role { get; set; }
        public int ExpiresIn { get; }

        public Token(string id, string authToken, int expiresIn, string role)
        {
            Id = id;
            AuthToken = authToken;
            ExpiresIn = expiresIn;
            Role = role;
        }
    }
}
