using System.ComponentModel.DataAnnotations;

namespace MoneyMate.Models.Expense;

public class ExpenseCreate
{
    [Required]
    public double Amount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    public string? Description { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [Required]
    public int PaymentId { get; set; }

    [Required]
    public int CurrencyId { get; set; }

    public string UserId { get; set; }
}





