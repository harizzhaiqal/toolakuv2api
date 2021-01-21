using System.Collections.Generic;
using System.Net.Http;
using Toolaku.Models.DTO;

namespace Toolaku.Models.Account
{
    public class SignInResponse
    {
        public SignInResponse()
        {
            this.Token = "";
            this.responseMsg = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.Unauthorized };
        }

        public string Token { get; set; }
        public HttpResponseMessage responseMsg { get; set; }

    }
}
