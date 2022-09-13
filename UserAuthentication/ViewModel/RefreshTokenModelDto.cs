namespace Authentication.ViewModel
{
    public class RefreshTokenModelDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string tenantCode { get; set; }
        public string username { get; set; }
    }
}
