using System.ComponentModel.DataAnnotations;
using Vitkir.UserManager.Common.DigitalSignatureWorker;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.PL.WebApp.Models.Account
{
    public class DigitalSignatureAuthentication : AbstractAccountModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Подпись")]
        public string Sign { get; set; }

        public DigitalSignatureAuthentication()
        {
        }

        public DigitalSignatureAuthentication(string login, string sign) : base(login)
        {
            Sign = sign;
        }

        public void GetLoginFromCms()
        {
            var auth = new UserAuthentication();
            Login = auth.GetLogin(Sign);
        }

        public bool VerifySignature(Common.Entities.Account account)
        {
            var auth = new UserAuthentication();
            return auth.VerifySignature(account, Sign);
        }
    }
}