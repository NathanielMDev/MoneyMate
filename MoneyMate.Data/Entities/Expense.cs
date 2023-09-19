using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyMate.Data.Entities;

public class Expense
{
    [Key]
    public int ExpenseId { get; set; }

    public double Amount { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    public virtual ExpenseCategory? Category { get; set; }

    [ForeignKey("PaymentId")]
    public int PaymentId { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }

    [ForeignKey("CurrencyId")]
    public int CurrencyId { get; set; }

    public virtual Currency? Currency { get; set; }

}
