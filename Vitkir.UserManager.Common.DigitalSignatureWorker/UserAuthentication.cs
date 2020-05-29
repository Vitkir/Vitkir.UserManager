using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Vitkir.UserManager.Common.DigitalSignatureWorker
{
	public class UserAuthentication
	{
		public bool VerifySignature(string cms)
		{
			
			byte[] bytes = Convert.FromBase64String(cms);
			SignedCms signedCms = new SignedCms();
			signedCms.Decode(bytes);

			if (signedCms.SignerInfos.Count == 0)
			{
				return false;
			}
			var signerInfoCollection = signedCms.SignerInfos;

			try
			{
				signerInfoCollection[0].CheckSignature(false);
				return true;
			}
			catch (CryptographicException)
			{
				return false;
			}
		}

		public void EncriptMessage()
		{

		}

		private X509Certificate2 GetSertificate()
		{
			throw new NotImplementedException();
		}
	}
}
