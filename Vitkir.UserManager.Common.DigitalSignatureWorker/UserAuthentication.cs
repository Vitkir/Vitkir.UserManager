using System;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.Common.DigitalSignatureWorker
{
    public class UserAuthentication
    {
        public bool VerifySignature(Account account, string cms)
        {
            byte[] bytes = Convert.FromBase64String(cms);
            SignedCms signedCms = new SignedCms();
            signedCms.Decode(bytes);

            if (signedCms.SignerInfos.Count == 0)
            {
                return false;
            }
            var signerInfo = signedCms.SignerInfos[0];

            var subjectData = signerInfo.Certificate.SubjectName.Decode(X500DistinguishedNameFlags.UseNewLines);


            var name = Regex.Match(subjectData, @"CN=(\S*)\s").Groups[1].Value;

            if (account.Login != name)
            {
                return false;
            }

            try
            {
                signerInfo.CheckSignature(false);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetLogin(string cms)
        {
            byte[] bytes = Convert.FromBase64String(cms);
            SignedCms signedCms = new SignedCms();
            signedCms.Decode(bytes);

            var content = signedCms.ContentInfo.Content;

            return Encoding.Unicode.GetString(content);
        }
    }
}
