using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetBanking.Identity.Configurations
{
    public class JwtOptions
    {
        //"http://localhost"
        public string Issuer { get; set; }
        public string SecuryKey { get; set; }
        public string Expiration { get; set; }

    }
}
