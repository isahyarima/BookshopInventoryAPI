using System.Collections.Generic;

namespace Authentication.ViewModel
{
    public class LoginResultDto
    {
        public bool WasSuccessful { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public List<string>  Activities { get; set; }
    }
}
