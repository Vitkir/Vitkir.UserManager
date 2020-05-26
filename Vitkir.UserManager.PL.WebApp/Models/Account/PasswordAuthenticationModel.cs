using System.ComponentModel.DataAnnotations;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.PL.WebApp.Models.Account
{
	public class PasswordAuthenticationModel :AbstractAccountModel
	{
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public Role Role { get; set; }

		public PasswordAuthenticationModel()
		{
		}

		public PasswordAuthenticationModel(string login, string password) : base(login)
		{
			Password = password;
		}
	}
}