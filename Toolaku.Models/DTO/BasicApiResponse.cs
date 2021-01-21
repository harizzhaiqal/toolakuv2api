using System;
using System.Collections.Generic;
using System.Text;

namespace Toolaku.Models.DTO
{
    public class BasicApiResponse : ResponseBase
    {
        public BasicApiResponse()
        {
            ReturnCode = 0;
            ResponseMessage = string.Empty;
        }

        public List<Dictionary<string, string>> Result { get; set; }
    }

    public class PostApiResponse : ResponseBase
    {
        public PostApiResponse()
        {
            ReturnCode = 0;
            ResponseMessage = string.Empty;
        }

        public int Id { get; set; }
    }
}
