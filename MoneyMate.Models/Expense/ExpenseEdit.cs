using System.ComponentModel.DataAnnotations;
namespace MoneyMate.Models.Expense;

public class ExpenseEdit
{
    [Key]
    public int ExpenseId { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public int PaymentId { get; set; }

    public int CurrencyId { get; set; }

}


