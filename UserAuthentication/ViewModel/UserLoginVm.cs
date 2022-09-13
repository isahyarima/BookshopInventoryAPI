using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.ViewModel
{
   public class UserLoginVm
    {
        public string UserName { get; set; }
        public string userName { get;  set; }
        public string Password { get; set; }
        public string password { get;  set; }
        public string Email { get; set; }
        public string TenantId { get; set; }
        public string TenantCode { get; internal set; }
        public string confirmationId { get; set; }
        public string link { get; set; }
        public int? userId { get; set; }

        //  public bool RememberMe { get; set; }
    }
}
