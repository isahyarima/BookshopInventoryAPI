namespace Footage.DTO
{
    public  class TokenRequestVM
    {
        public string GrantType { get; set; } // password or refresh_token
        public int ClientId { get; set; }
        public string userName { get; set; }
        public string refreshToken { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public int userId { get; set; }
        public int? roleId { get; set; }
        public string name { get; set; }
    }
}
