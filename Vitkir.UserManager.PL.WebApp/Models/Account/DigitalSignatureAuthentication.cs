using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.PL.WebApp.Models.Account
{
	public class DigitalSignatureAuthentication : AbstractAccountModel
	{
		public Role Role { get; set; }

		public byte[] Cms { get; set; }

		public DigitalSignatureAuthentication()
		{
		}

		public DigitalSignatureAuthentication(string login, byte[] cms) : base(login)
		{
			Cms = cms;
		}

		public bool VerifySignature()
		{

		}
	}
}