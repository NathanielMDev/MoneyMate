using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMate.Data.Entities;

public class Budget
{
    [Key]
    public int BudgetID { get; set; }

    public ICollection<Expense> Expenses { get; set; }

    public double Amount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public double TotalExpenses { get; set; }

    public double RemainingAmount => Amount - TotalExpenses;

    public double PreviousExpenses { get; set; }

}