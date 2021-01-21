namespace Toolaku.Models.Account
{
    public class ChangePasswordRequest
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class RecoverPasswordUsername
    {
        public string emailTo { get; set; }
    }
}
