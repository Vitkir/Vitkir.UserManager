using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vitkir.UserManager.PL.WebApp.Models.Account
{
	public abstract class AbstractAccountModel
	{
		[Required]
		[DataType(DataType.Text)]
		[Display(Name = "Логин")]
		public string Login { get; set; }

		public AbstractAccountModel()
		{
		}

		public AbstractAccountModel(string login)
		{
			Login = login;
		}
	}
}