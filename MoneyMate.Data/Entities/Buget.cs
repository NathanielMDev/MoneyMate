using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMate.Data.Entities;

public class Budget
{
    [Key]
    public int BudgetID { get; set; }

    [ForeignKey("Expense")]
    public int? ExpenseId { get; set; }

    public Expense? Expense { get; set; }

    public double Amount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

}