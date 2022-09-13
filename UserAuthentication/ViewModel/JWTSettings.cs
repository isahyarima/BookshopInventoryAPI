using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.ViewModel
{
  public  class JWTSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int MinutesToExpiration { get; set; }
    }
}
