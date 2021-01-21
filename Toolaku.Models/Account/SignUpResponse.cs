using Toolaku.Models.DTO;

namespace Toolaku.Models.Account
{
    public class SignUpResponse : ResponseBase
    {
        public SignUpResponse()
        {
            ReturnCode = 0;
            ResponseMessage = string.Empty;
        }

        public bool IsSuccessful { get; set; }
        public int UserId { get; set; }

    }

    public class RegisterResponse : ResponseBase
    {
        public int UserId { get; set; }
    }
}
