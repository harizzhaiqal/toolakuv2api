using Toolaku.Models.DTO;

namespace Toolaku.Models.Account
{
    public class LoginDetail : ResponseBase
    {
        public LoginDetail()
        {
            ReturnCode = 0;
            ResponseMessage = string.Empty;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string ImageURL { get; set; }
        public string Email { get; set; }

    }
}
