namespace MoneyMate.Models.Expense;

public class ExpenseIndex
{
    public int ExpenseId { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public string? ExpenseCategory { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Currency { get; set; }
}

