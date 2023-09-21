using System.Collections.Generic;
namespace MoneyMate.Models.ExpenseCategory
{
	public class CategoryExpensesView
	{
		public string CategoryName { get; set; }

		public List<MoneyMate.Data.Entities.Expense> Expenses { get; set; }
	}
}

