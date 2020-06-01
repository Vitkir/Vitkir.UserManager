using CryptoPro.Sharpei;
using System;
using System.ComponentModel;
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
			var signerInfo = signedCms.SignerInfos[0];
			//var hashoid = signerInfo.DigestAlgorithm;

			//var content = signedCms.ContentInfo.Content;
			//var contentStr = Encoding.Unicode.GetString(content);

			//var login = "user";
			//var bytesLogin = Encoding.Unicode.GetBytes(login);
			//Gost3411_2012_256CryptoServiceProvider hashAlg = new Gost3411_2012_256CryptoServiceProvider();
			//var loginhash = hashAlg.ComputeHash(bytesLogin);
			//var contenthash = hashAlg.ComputeHash(bytesLogin);
			try
			{
				signerInfo.CheckSignature(false);
				return true;
			}
			catch (ArgumentNullException)
			{
				return false;
			}
			catch (CryptographicException)
			{
				return false;
			}
			catch (InvalidOperationException)
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
