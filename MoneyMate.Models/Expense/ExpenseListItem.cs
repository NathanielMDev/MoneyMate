using System.ComponentModel.DataAnnotations;

namespace MoneyMate.Models.Expense;

public class ExpenseListItem
{
    public int Id { get; set; }

    public double Amount { get; set; }

    public string? Description { get; set; }

    public DateTime Date { get; set; }

    public string? ExpenseCategory { get; set; }

    public int CategoryId { get; set; }

}

