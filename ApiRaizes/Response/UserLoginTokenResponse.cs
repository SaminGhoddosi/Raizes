using ApiRaizes.Entity;

namespace ApiRaizes.Response.User
{
    public class UserLoginTokenResponse
    {
        public string Token { get; set; }
        public UserEntity User { get; set; }
    }
}