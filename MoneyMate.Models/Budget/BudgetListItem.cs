using System;
namespace MoneyMate.Models.Budget
{
	public class BudgetListItem
	{
        public double Amount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double TotalExpenses { get; set; }

        public double RemainingAmount => Amount - TotalExpenses;

        public string? Expenses { get; set; }

        
    }
}

