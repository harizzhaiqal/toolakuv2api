using System;
using System.Collections.Generic;
using System.Text;
using Toolaku.Models.DTO;
using Toolaku.Models.Reference;

namespace Toolaku.Models.Account
{
    public class UserModules : ResponseBase
    {
        public UserModules()
        {
            ReturnCode = 0;
            ResponseMessage = string.Empty;
        }

        public List<Module> Result { get; set; }
    }
}
