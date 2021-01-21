using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.Account
{
    public class AuthenticateResult
    {
        public string Status { get; set; }
        public int ReturnCode { get; set; }
        public string UserId { get; set; }
        public string TenantId { get; set; }
    }
}
