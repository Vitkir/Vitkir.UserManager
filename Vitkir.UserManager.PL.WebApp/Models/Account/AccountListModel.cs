using System.ComponentModel.DataAnnotations;
using Vitkir.UserManager.Common.Entities;

namespace Vitkir.UserManager.PL.WebApp.Models.Account
{
	public class AccountListModel : AbstractAccountModel
	{
		[ScaffoldColumn(false)]
		public int Id { get; set; }

		[DataType(DataType.Text)]
		[Display(Name = "Статус")]
		public Role Role { get; set; }

		public AccountListModel()
		{
		}

		public AccountListModel(string login) : base(login)
		{
		}
	}
}